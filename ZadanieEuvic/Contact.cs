using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace ZadanieEuvic
{
    /// <summary>
    /// Represent a contact object with name and surname fields by providing a string. Additionaly inputs a list of names file to chceck if string starts with name or surname 
    /// </summary>
    public class Contact : IComparable<Contact>, IGiveNameSurname
    {
        private static List<string> listOfPolishNames = new List<string>();
        private string name;
        private string surname;
        /// <summary>
        /// Contact class with special list to determine if the string is a polish name
        /// </summary>

        public Contact(string inputNameSurname) 
        {
            if (listOfPolishNames.Count() < 1)
            {
                try
                {
                    string nameBase = new FileReader().ReadGivenFile("imiona.txt");
                    var names = Regex.Matches(nameBase, @"\p{Lu}\p{Ll}+");
                    foreach (Match match in names)
                    {
                        listOfPolishNames.Add(match.Value);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("No file with names in directory ");
                    Console.ReadKey();
                }
            }
            SetContactNameSurname(inputNameSurname);
        }
        /// <summary>
        /// Sets Contact name and surname from given string
        /// </summary>
        /// <param name="inputNameSurname"></param>
        private void SetContactNameSurname(string inputNameSurname)
        {
            var firstPart = inputNameSurname.Split(' ')[0];
            var secondPart = inputNameSurname.Replace(" ", "").Replace(firstPart, "");
            if (listOfPolishNames.Contains(firstPart))
            {
                name = firstPart;
                surname = secondPart;
            } 
            else
            {
                name = secondPart;
                surname = firstPart;
            }
        }

        /// <summary>
        /// IComparaTo method
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public int CompareTo(Contact contact)
        {
            if (contact.surname.CompareTo(this.surname) == -1) return -1;
            else if (contact.surname.CompareTo(this.surname) == 1) return 1;
            else
            {
                if (contact.name.CompareTo(this.surname) == -1) return -1;
                else if(contact.name.CompareTo(this.name) == 1) return 1;
                else return 0;
            }
        }
        /// <summary>
        /// Returns a string created from surname and name fields with " " between.
        /// </summary>
        /// <returns></returns>
        public string GiveNameSurname()
        {
            return String.Join(" ", surname, name);
        }
    }
}
