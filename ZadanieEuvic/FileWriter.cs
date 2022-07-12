using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieEuvic
{
    /// <summary>
    /// Writes strings to file
    /// </summary>
    public class FileWriter : IWriteListToFile
    {
        /// <summary>
        /// Creates or opens and rewrites a file, provided by the user and writes contacts names and surnames 
        /// </summary>
        /// <param name="listToWrite"></param>
        /// <param name="nameOfFile"></param>
        public void WriteListToFile(List<Contact> listToWrite, string nameOfFile)
        {
            if (listToWrite.Count == 0) throw new ArgumentNullException("The list is empty");
            if (string.IsNullOrWhiteSpace(nameOfFile)) throw new ArgumentNullException("The path to file is empty");
            try
            {
                var streamWriter = new StreamWriter(nameOfFile, append: true);
                listToWrite.ForEach(x =>
                {
                    streamWriter.WriteLine(x.GiveNameSurname());
                });
                streamWriter.Close();
                Console.WriteLine("File Written succesfully");
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The file was not saved");
                Console.ReadKey();
            }
        }
    }
}
