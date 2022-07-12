using System.Collections.Generic;

namespace ZadanieEuvic
{
    public interface IWriteListToFile
    {
        void WriteListToFile(List<Contact> listToWrite, string pathOfFile);

    }
}