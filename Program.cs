using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBook
    {
        public List<Contact> contacts { get; set; }
        public int numberOfContacts { get; set; }

        public AddressBook()
        {
            this.contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            numberOfContacts = contacts.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System!");

            var contact = TakeInputForContact();
            var addressbook1 = new AddressBook();
            addressbook1.AddContact(contact);
        }

        static Contact TakeInputForContact()
        {
            Console.WriteLine("Enter First Name : ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name : ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Address Line One : ");
            var addressLineOne = Console.ReadLine();

            Console.WriteLine("Enter City : ");
            var city = Console.ReadLine();

            Console.WriteLine("Enter State : ");
            var state = Console.ReadLine();

            Console.WriteLine("Enter Zip : ");
            var zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Phone No. : ");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email : ");
            var email = Console.ReadLine();

            var address = new Address(addressLineOne, city, state, zip);
            return new Contact(firstName, lastName, address, phoneNumber, email);
        }



    }
}
