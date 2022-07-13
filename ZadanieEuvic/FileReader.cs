using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieEuvic
{
    /// <summary>
    /// Support file reader class
    /// </summary>
    public class FileReader : IReadGivenFile
    {
        /// <summary>
        /// Reads a file located in HD
        /// </summary>
        /// <param name="HDadress"></param>
        /// <returns>String</returns>
        public string ReadGivenFile(string HDadress)
        {
            if (!string.IsNullOrWhiteSpace(HDadress))
            {
                string fileStream = "";
                try
                {
                    var stremReader = new StreamReader(HDadress);
                    fileStream = stremReader.ReadToEnd();
                    stremReader.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("File missing or can't open given file.");
                }
                return fileStream;
            }
            else throw new ArgumentNullException("No path to file given");
        }
    }
}
