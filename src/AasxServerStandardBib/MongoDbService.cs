using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using AdminShellNS;
using AasCore.Aas3_0_RC02;
using MongoDB.Bson.Serialization;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;

namespace AasxServerStandardBib
{
    public class MongoDBService
    {
        public MongoDBService()
        {
            this.dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            Database = dbClient.GetDatabase("AASEnv");
            BsonClassMap.RegisterClassMap<Submodel>();
            BsonClassMap.RegisterClassMap<AssetAdministrationShell>();
            BsonClassMap.RegisterClassMap<Property>();
            BsonClassMap.RegisterClassMap<SubmodelElementCollection>();
            BsonClassMap.RegisterClassMap<File>();
            BsonClassMap.RegisterClassMap<BasicEventElement>();
            BsonClassMap.RegisterClassMap<Blob>();
            BsonClassMap.RegisterClassMap<Operation>();
            BsonClassMap.RegisterClassMap<ReferenceElement>();
            BsonClassMap.RegisterClassMap<MultiLanguageProperty>();
            BsonClassMap.RegisterClassMap<AasEnv>();
        }

        private MongoClient dbClient;
        private static IMongoDatabase Database;

        public int GetAASEnvCount()
        {
            return (int)Database.GetCollection<AasEnv>("AasEnv").CountDocuments("{ }");
        }

        public class AasEnv
        {
            public List<string> AasIds = new List<string>();
            public List<string> SubmodelIds = new List<string>();
            public string Filename = string.Empty;
            [BsonId]
            internal string _id = string.Empty;

            internal AasEnv(string fileName, string id)
            {
                Filename = fileName;
                this._id = id;
            }

            public AdminShellPackageEnv ToAdminShellPackageEnv()
            {
                List<Submodel> submodels = GetSubmodels(SubmodelIds);
                List<AssetAdministrationShell> assetAdministrationShells = GetAass(AasIds);
                var env = new Environment(assetAdministrationShells, submodels);
                var aasenv = (new AdminShellPackageEnv(env));
                aasenv.id = _id;
                return aasenv;
            }

            private static List<Submodel> GetSubmodels(List<string> submodelIds)
            {
                List<Submodel> submodels = new List<Submodel>();
                foreach (string id in submodelIds)
                {
                    if (TryGetSubmodel(id, out Submodel sm))
                    {
                        submodels.Add(sm);
                    }
                }
                return submodels;
            }

            private static List<AssetAdministrationShell> GetAass(List<string> aasIds)
            {
                List<AssetAdministrationShell> aass = new List<AssetAdministrationShell>();
                foreach (string id in aasIds)
                {
                    if (TryGetAAS(id, out AssetAdministrationShell aas))
                    {
                        aass.Add(aas);
                    }
                }
                return aass;
            }
        }


        public void CreateAASEnv(AdminShellPackageEnv env, string fn)
        {
            if(TryGetEnv(env.id, out AasEnv aasEnv))
            {
                // update
            }
            else
            {
                aasEnv = new AasEnv(fn, env.id);
                CreateAASs(env.AasEnv.AssetAdministrationShells);
                aasEnv.AasIds = (from item in env.AasEnv.AssetAdministrationShells select item.Id).ToList();
                CreateSubmodels(env.AasEnv.Submodels);
                aasEnv.SubmodelIds = (from item in env.AasEnv.Submodels select item.Id).ToList();

                Database.GetCollection<AasEnv>("AasEnv").InsertOne(aasEnv);
            }
            
        }

        public void UpdateAASEnv(Environment env)
        {
            UpdateSubmodels(env);
            UpdateAASs(env.AssetAdministrationShells);
        }

        private void UpdateSubmodels(Environment env)
        {
            Database.GetCollection<Submodel>("Submodel").DeleteMany("{ }");
            Database.GetCollection<Submodel>("Submodel").InsertMany(env.Submodels);
        }

        private void UpdateAASs(List<AssetAdministrationShell> assetAdministrationShells)
        {
            Database.GetCollection<AssetAdministrationShell>("AssetAdministrationShell").DeleteMany("{ }");
            Database.GetCollection<AssetAdministrationShell>("AssetAdministrationShell").InsertMany(assetAdministrationShells);
        }

        private void CreateSubmodels(List<Submodel> submodels)
        {
            foreach (var sm in submodels)
            {
                if (!TryGetSubmodel(sm.Id, out _))
                {
                    CreateSubmodel(sm);
                }
            }
        }

        private void CreateSubmodel(Submodel sm)
        {
            Database.GetCollection<Submodel>("Submodel").InsertOne(sm);
        }

        public List<AssetAdministrationShell> GetAASList()
        {
            return Database.GetCollection<AssetAdministrationShell>("AssetAdministrationShell").Aggregate().ToList();
        }
        
        public void CreateAAS(AssetAdministrationShell aas)
        {
            Database.GetCollection<AssetAdministrationShell>("AssetAdministrationShell").InsertOne(aas);
        }

        public void CreateAASs(List<AssetAdministrationShell> aasList)
        {
            foreach (var aas in aasList)
            {
                if (!TryGetAAS(aas.Id, out _))
                {
                    CreateAAS(aas);
                }
            }
        }

        public List<AasEnv> GetAllAasEnvs()
        {
            return Database.GetCollection<AasEnv>("AasEnv").Find(_ => true).ToList();
        }

        public static bool TryGetAAS(string id, out AssetAdministrationShell aas)
        {
            var filter = Builders<AssetAdministrationShell>.Filter.Eq("_id", id);
            aas = Database.GetCollection<AssetAdministrationShell>("AssetAdministrationShell").Find(filter).FirstOrDefault();
            if(aas == null)
            {
                return false;
            }

            return true;
        }

        public static bool TryGetSubmodel(string id, out Submodel sm)
        {
            var filter = Builders<Submodel>.Filter.Eq("_id", id);
            sm = Database.GetCollection<Submodel>("Submodel").Find(filter).FirstOrDefault();
            if (sm == null)
            {
                return false;
            }

            return true;
        }
        internal bool TryGetEnv(string id, out AasEnv env)
        {
            var filter = Builders<AasEnv>.Filter.Eq("_id", id);
            env = Database.GetCollection<AasEnv>("AasEnv").Find(filter).FirstOrDefault();
            if (env == null)
            {
                return false;
            }

            return true;
        }
    }
}