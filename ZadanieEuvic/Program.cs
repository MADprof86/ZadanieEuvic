using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieEuvic
{
    class Program
    {
        static List<Contact> listOfContacts = new List<Contact>();
        /// <summary>
        /// Trims and lowers caracters of given string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        static string StringTrimmer(string input)
        {
            return input.ToLower().Trim();
        }
        /// <summary>
        /// Sorts descending the main list of contacts
        /// </summary>
        static void ContactListSorter()
        {
            listOfContacts.Sort();
            listOfContacts.Reverse();
        }
        /// <summary>
        /// Basic GUI
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string inputCommand = null;
            Console.WriteLine("Welcome to the contact list evaluator.");
            Console.ReadKey();
            do
            {
                inputCommand = "";
                Console.Clear();
                Console.WriteLine("Open\t - open given file and write contacts" +
                    "\nList\t - review the contact list" +
                    "\nWrite\t - write the contacts to given file" +
                    "\nDelete\t - delete the contact list" +
                    "\nX\t - close aplication");
                Console.WriteLine("Enter command:");
                inputCommand = Console.ReadLine();
                if(StringTrimmer(inputCommand) == "open")
                {
                    Console.WriteLine("Write path to file");
                    var filePath = StringTrimmer(Console.ReadLine());
                    try
                    {
                        var contactString = new FileReader().ReadGivenFile(filePath);
                        listOfContacts.AddRange(new NameAndSurnameFilter().FilterNameSurnameFromString(contactString));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else if (StringTrimmer(inputCommand) == "list")
                {
                    if (listOfContacts.Count == 0)
                    {
                        Console.WriteLine("The list is empty");
                    }
                    else
                    {
                        ContactListSorter();
                        listOfContacts.ForEach(x => Console.WriteLine(x.GiveNameSurname()));
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else if(StringTrimmer(inputCommand) == "write")
                {
                    if (listOfContacts.Count == 0)
                    {
                        Console.WriteLine("The list is empty. No file was created.");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                    else
                    {
                        ContactListSorter();
                        Console.WriteLine("Write file name. If the file is not empty, the contacts will be written in the end of the file.");
                        var filePath = StringTrimmer(Console.ReadLine());
                        try
                        {
                            new FileWriter().WriteListToFile(listOfContacts, filePath);
                            Console.ReadKey();
                        }
                        catch(ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                    }
                }
                else if(StringTrimmer(inputCommand) == "delete")
                {
                    listOfContacts.Clear();
                    Console.WriteLine("List cleared.");

                }
                } while (inputCommand.ToLower() != "x");
            Console.WriteLine("Aplication terminated");
        }
    }
}

