using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.Write("1. Save/Write to .txt file\n2. Read from  .txt file\n3. Write to a .csv file\n4.Read from the .csv file\n5. Write to .Json file\n6.Read from .Json file\nEnter your option :");
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
                case 3:
                    path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".csv";
                    using (var writer = new StreamWriter(path))
                    using (var csvWriter = new CsvWriter(writer,CultureInfo.InvariantCulture))
                    {
                        var clist = addressBooks[name].SortByName().ToList();
                        csvWriter.WriteRecords(clist);
                    }
                    break;
                case 4:
                    path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".csv";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("No Such File Exists, Please Save before reading.");
                        break;
                    }
                    using(var reader = new StreamReader(path))
                    using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var contactList = csvReader.GetRecords<Contact>().ToList();
                        Console.WriteLine("There are following contacts saved in file : ");
                        foreach(var contact in contactList)
                        {
                            Program.DisplayContact(contact);
                        }
                    }
                    break;
                case 5:
                    path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".json";
                    var list = addressBooks[name].SortByName().ToList();
                    var copy = new List<Contact>();
                    foreach (var item in list)
                        copy.Add(item.Value);
                    var serializer = new JsonSerializer();
                    using(var streamWriter = new StreamWriter(path))
                    using(var jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        serializer.Serialize(jsonWriter, copy);
                    }
                    break;
                case 6:
                    path = @"C:\Users\Mayank\Desktop\testing\CSharp-Project\" + name + ".json";
                    var contacts = JsonConvert.DeserializeObject<List<KeyValuePair<string, Contact>>>(File.ReadAllText(path));
                    foreach (var contact in contacts)
                        Program.DisplayContact(contact.Value);
                    break;
            }
        }
    }
}
