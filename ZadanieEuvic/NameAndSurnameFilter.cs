using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZadanieEuvic
{
    /// <summary>
    /// Class that filters the name and surname form input string
    /// </summary>
    public class NameAndSurnameFilter : IFilterNameSurnameFromString
    {
        /// <summary>
        /// Takes given string and returns a list of contacts with name and surname
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List of Contact objects</returns>
        public List<Contact> FilterNameSurnameFromString(string input)
        {
            var namesAndSurnames = Regex.Matches(input, @"\b((?'Imie'\p{Lu}\p{Ll}+)[ ]*)+");
            var outputList = new List<Contact>();
            foreach (Match match in namesAndSurnames)
            {
                outputList.Add(new Contact(match.Value));
            }
            return outputList;
        }
    }
}
