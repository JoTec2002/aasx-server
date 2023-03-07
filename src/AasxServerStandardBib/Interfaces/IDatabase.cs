using System.Collections.Generic;

namespace AasxServerStandardBib
{
    public interface IDatabase
    {
        string getValue(string id, string key);

        List<byte[]> getAllAasx();

        void addValue(string id,string key, string value);

        void addAas(string id, byte[] aasFile);

        void removeValue(string id, string key);

        void removeAas(string id);
    }
}