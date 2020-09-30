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

            var contact = new Contact("Iron","Man", new Address("stark industries","NYC","New York",22211),
                "+1121212","ironman@gmail.com");
            var addressbook1 = new AddressBook();
            addressbook1.AddContact(contact);
        }


        
    }
}
