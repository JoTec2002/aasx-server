using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AasxServer;

namespace AasxServerStandardBib
{
    public class AasDataProvider : IDatabase
    {
        public AasDataProvider()
        {
            new AasContext();
        }

        public string getValue(string id,string key)
        {
            var aas = AasContext.AasCollection.Where(aas => aas.Id == id).FirstOrDefault();
            if (aas!=null)
            {
                bool foundValue = aas.Values.TryGetValue(key, out string value);
                if (foundValue) 
                {
                    return value; 
                }
                throw new ArgumentException("The given key was not found in the AAS.");
            }
            throw new ArgumentException("An aas with the given Id was not found.");
        }

        public List<byte[]> getAllAasx()
        {
            List<byte[]> aasList = new List<byte[]>();
            foreach(var aas in AasContext.AasCollection)
            {
                aasList.Add(aas.AasFile);
            }
            return aasList;
        }

        public void addValue(string id,string key, string value)
        {
            var aas = AasContext.AasCollection.Where(aas => aas.Id == id).FirstOrDefault();
            if (aas != null)
            {
                aas.Values.Add(key, value);
            }
            throw new ArgumentException("An aas with the given Id was not found.");
        }

        public void addAas(string id, byte[] aasFile)
        {
            AasContext.Aas aas = new AasContext.Aas(id, aasFile);
            AasContext.AasCollection.Add(aas);
        }

        public void removeValue(string id,string key)
        {
            var aas = AasContext.AasCollection.Where(aas => aas.Id == id).FirstOrDefault();
            if (aas != null)
            {
                bool foundValue = aas.Values.TryGetValue(key, out string value);
                if (foundValue)
                {
                    aas.Values.Remove(key);
                }
                throw new ArgumentException("The given key was not found in the AAS.");
            }
            throw new ArgumentException("An aas with the given Id was not found.");
        }

        public void removeAas(string id)
        {
            var aas = AasContext.AasCollection.Where(aas => aas.Id == id).FirstOrDefault();
            if (aas != null)
            {
                AasContext.AasCollection.Remove(aas);
            }
            throw new ArgumentException("An aas with the given Id was not found.");
        }
    }
}
