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
                if (listOfContacts.Count > 0) listOfContacts.OrderByDescending(x=>x);
                inputCommand = "";
                Console.Clear();
                Console.WriteLine("Open\t - open given file and write contacts" +
                    "\nList\t - review the contact list" +
                    "\nWrite\t - write the contacts to given file" +
                    "\nDelete\t - delete the contact list" +
                    "\nX\t - close aplication");
                Console.WriteLine("Enter command:");
                inputCommand = Console.ReadLine();
                if(inputCommand.ToLower() == "open")
                {
                    Console.WriteLine("Write path to file");
                    var filePath = Console.ReadLine().ToLower();
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
                else if (inputCommand.ToLower() == "list")
                {
                    if (listOfContacts.Count == 0)
                    {
                        Console.WriteLine("The list is empty");
                    }
                    else
                    {
                        listOfContacts.ForEach(x => Console.WriteLine(x.GiveNameSurname()));
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else if(inputCommand.ToLower() == "write")
                {
                    if (listOfContacts.Count == 0)
                    {
                        Console.WriteLine("The list is empty. No file was created.");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Write file name. If the file is not empty, the contacts will be written in the end of the file.");
                        var filePath = Console.ReadLine().ToLower();
                        new FileWriter().WriteListToFile(listOfContacts, filePath);
                        Console.ReadKey();

                    }
                }
                else if(inputCommand.ToLower() == "delete")
                {
                    listOfContacts.Clear();
                    Console.WriteLine("List cleared.");

                }
                } while (inputCommand.ToLower() != "x");
            Console.WriteLine("Aplication terminated");
        }
    }
}

