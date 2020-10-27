using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        public static AddressBookManager addressBookManager;
        public static Dictionary<string, AddressBook> addressBooks;
        public static Dictionary<string, List<Contact>> cityContactMap;
        public static Dictionary<string, List<Contact>> stateContactMap;

        static void Main(string[] args)
        {
            addressBookManager = new AddressBookManager();
            addressBooks = addressBookManager.addressBooks;
            cityContactMap = addressBookManager.cityContactMap;
            stateContactMap = addressBookManager.stateContactMap;


            Console.WriteLine("Welcome to Address Book System!");

            var quit = false;

            while (!quit)
            {
                Console.Write("Choose an option\n1.Create New Address Book\n2.Open an address book\n3.View Persons by City\n4.View Persons by state" +
                    "\n5.Search a person in a city\n6.Search a person in a state" +
                    "\n7.Quit\nEnter Your Option :");
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Write("Enter a name for your address book :");
                        var name = Console.ReadLine();
                        addressBooks.Add(name, new AddressBook());
                        InitializeAddressBook(name);
                        break;
                    case 2:
                        Console.Write("Enter name of the address book to open :");
                        name = Console.ReadLine();
                        if (!addressBooks.ContainsKey(name))
                            Console.WriteLine("No Such Address Book Exists!");
                        else
                            InitializeAddressBook(name);
                        break;
                    case 3:
                        Console.Write("Enter the city : ");
                        var city = Console.ReadLine();

                        if (!addressBookManager.cityContactMap.ContainsKey(city))
                            Console.WriteLine("No Such City Exists");
                        else
                        {
                            Console.WriteLine("Found {0} Results : ", addressBookManager.cityContactMap[city].Count);
                            int i = 1;
                            foreach (var item in addressBookManager.cityContactMap[city])
                                Console.WriteLine("{0}. {1}", i++, item.firstName); ;
                        }
                        break;
                    case 4:
                        Console.Write("Enter the state :");
                        var state = Console.ReadLine();

                        if (!addressBookManager.stateContactMap.ContainsKey(state))
                            Console.WriteLine("No Such State Exists");
                        else
                        {
                            Console.WriteLine("Found {0} Results : ", addressBookManager.stateContactMap[state].Count);
                            int i = 1;
                            foreach (var item in addressBookManager.stateContactMap[state])
                                Console.WriteLine("{0}. {1}", i++, item.firstName); ;
                        }
                        break;
                    case 5:
                        Console.Write("Enter City to Search in : ");
                        var searchCity = Console.ReadLine();
                        Console.Write("Enter name to search : ");
                        var searchName = Console.ReadLine();
                        var list = addressBookManager.SearchInCity(searchName, searchCity);
                        if (list == null)
                            Console.WriteLine("No Such City in Address Books.");
                        else
                            Console.WriteLine("Found {0} persons named {1} in {2}", list.Count, searchName, searchCity);
                        break;
                    case 6:
                        Console.Write("Enter State to Search in : ");
                        var searchState = Console.ReadLine();
                        Console.Write("Enter name to search : ");
                        searchName = Console.ReadLine();
                        list = addressBookManager.SearchInState(searchName, searchState);
                        if (list == null)
                            Console.WriteLine("No Such State in Address Books.");
                        else
                            Console.WriteLine("Found {0} persons named {1} in {2}", list.Count, searchName, searchState);
                        break;
                    case 7:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }
        }

        static void InitializeAddressBook(string name)
        {
            const string Console_Message = "########################You are in {0}#######################\n" +
                " Please select an option : \n1.Add Contact\n2.Edit existing Contact\n3.Delete existing Contact\n" +
                "4.Sort Contacts by City\n5.Sort Contacts by State\n6.Sort Contacts by Zip\n7.Sort By Name\n8.Quit\nEnter your option :";

            //Adding a contact to contact book
            var addressbook = addressBooks[name];
            addressbook.AddContact(new Contact("A", "Raja",
                new Address("Bazar A", "CKolkata", "AWB", 1453), "12345", "gmail.com"));
            addressbook.AddContact(new Contact("B", "Raja",
                new Address("Bazar A", "Akolkata", "CWB", 1452), "12345", "gmail.com"));
            addressbook.AddContact(new Contact("C", "Raja",
                new Address("Bazar A", "Bkolkata", "BWB", 1451), "12345", "gmail.com"));
            addressBookManager.AddToCityMap(addressbook.contacts["B"]);
            addressBookManager.AddToCityMap(addressbook.contacts["A"]);
            addressBookManager.AddToStateMap(addressbook.contacts["B"]);
            addressBookManager.AddToStateMap(addressbook.contacts["A"]);



            bool quit = false;

            while (quit != true)
            {
                Console.Write(Console_Message,name);
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        var newContact = TakeInputForContact();
                        addressbook.AddContact(newContact);
                        addressBookManager.AddToCityMap(newContact);
                        addressBookManager.AddToStateMap(newContact);
                        break;
                    case 2:
                        //Editing by using first name of the contact
                        Console.Write("Enter the name of the person to edit contact details :");
                        var firstName = Console.ReadLine();

                        if (!addressbook.contacts.ContainsKey(firstName))
                            Console.WriteLine("No record(s) found");
                        else
                        {
                            var contactToEdit = addressbook.contacts[firstName];
                            Console.WriteLine("################ The existing details are ############");
                            DisplayContact(contactToEdit);
                            Console.WriteLine("################ Enter the new details ############");
                            var contact = TakeInputForContact();
                            addressbook.EditContact(firstName, contact);
                        }
                        break;
                    case 3:
                        //Deleting by using first name of the contact
                        Console.Write("Enter the name of the person to edit contact details :");
                        var firstNameToDelete = Console.ReadLine();
                        addressbook.DeleteContact(firstNameToDelete);
                        break;
                    //Calling sort methods of addressbook class
                    case 4:
                        var sortedByCity = addressbook.SortByCity();
                        foreach (var contact in sortedByCity)
                            DisplayContact(contact.Value);
                        break;
                    case 5:
                        var sortedByState = addressbook.SortByState();
                        foreach (var contact in sortedByState)
                            DisplayContact(contact.Value);
                        break;
                    case 6:
                        var sortedByZip = addressbook.SortByZip();
                        foreach (var contact in sortedByZip)
                            DisplayContact(contact.Value);
                        break;
                    case 7:
                        var sortedByName = addressbook.SortByName();
                        foreach (var contact in sortedByName)
                            DisplayContact(contact.Value);
                        break;
                    case 8:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        static Contact TakeInputForContact()
        {
            Console.Write("Enter First Name : ");
            var firstName = Console.ReadLine();

            Console.Write("Enter Last Name : ");
            var lastName = Console.ReadLine();

            Console.Write("Enter Address Line One : ");
            var addressLineOne = Console.ReadLine();

            Console.Write("Enter City : ");
            var city = Console.ReadLine();

            Console.Write("Enter State : ");
            var state = Console.ReadLine();

            Console.Write("Enter Zip : ");
            var zip = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Phone No. : ");
            var phoneNumber = Console.ReadLine();

            Console.Write("Enter Email : ");
            var email = Console.ReadLine();

            var address = new Address(addressLineOne, city, state, zip);
            return new Contact(firstName, lastName, address, phoneNumber, email);
        }

        static void DisplayContact(Contact contact)
        {
            Console.WriteLine(" First Name : {0}",contact.firstName);
            Console.WriteLine(" Last Name : {0}",contact.lastName);
            Console.WriteLine(" Address Line One : {0}", contact.address.addressLineOne);
            Console.WriteLine(" City : {0}",contact.address.city);
            Console.WriteLine(" State : {0}",contact.address.state);
            Console.WriteLine(" Zip : {0}",contact.address.zip);
            Console.WriteLine(" Phone No. : {0}",contact.phoneNumber);
            Console.WriteLine(" Email : {0}",contact.email);
            Console.WriteLine("-----------------------------------");
        }
    }
}
