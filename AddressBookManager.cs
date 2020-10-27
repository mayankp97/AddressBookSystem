using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookManager
    {
        public Dictionary<string, AddressBook> addressBooks;

        public Dictionary<string, List<Contact>> cityContactMap;

        public Dictionary<string, List<Contact>> stateContactMap;


        public AddressBookManager()
        {
            addressBooks = new Dictionary<string, AddressBook>();
            cityContactMap = new Dictionary<string, List<Contact>>();
            stateContactMap = new Dictionary<string, List<Contact>>();
        }

        public void AddToCityMap(Contact contact)
        {
            if (cityContactMap.ContainsKey(contact.address.city))
                cityContactMap[contact.address.city].Add(contact);
            else
                cityContactMap.Add(contact.address.city, new List<Contact> { contact });
        }

        public void AddToStateMap(Contact contact)
        {
            if (stateContactMap.ContainsKey(contact.address.state))
                stateContactMap[contact.address.state].Add(contact);
            else
                stateContactMap.Add(contact.address.state, new List<Contact> { contact });
        }

        public List<Contact> SearchInCity(string firstName,string city)
        {
            if (!cityContactMap.ContainsKey(city))
                return null;
            return cityContactMap[city].Where(C => C.firstName == firstName).ToList();
        }

        public List<Contact> SearchInState(string firstName, string state)
        {
            if (!stateContactMap.ContainsKey(state))
                return null;
            return stateContactMap[state].Where(C => C.firstName == firstName).ToList();
        }

        public void DoIO(string name)
        {
            Console.Write("1. Save/Write as .txt file\n2. Read a .txt file\nEnter your option :");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    var path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".txt";
                    using (var streamWriter = File.AppendText(path))
                    {
                        foreach (var contact in addressBooks[name].contacts)
                        {
                            streamWriter.WriteLine(contact.Value.firstName + " " + contact.Value.lastName);
                        }
                        streamWriter.Close();
                    }
                    break;
                case 2:
                    path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("No Such File Exists");
                        break;
                    }
                    using (var streamReader = File.OpenText(path))
                    {
                        string str = "";
                        while ((str = streamReader.ReadLine()) != null)
                            Console.WriteLine(str);
                    }
                    break;
            }
        }
    }
}
