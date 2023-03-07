using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AasxServerStandardBib
{
    public class AasContext : DbContext
    {

        public static DbSet<Aas> AasCollection;

        public AasContext()
        {
        }

        public class Aas
        {
            public string Id;
            public byte[] AasFile;

            public Aas(string id, byte[] aasFile)
            {
                Id = id;
                AasFile = aasFile;
            }

            public Dictionary<string, string> Values { get; set; } = new();
        }
    }
}
