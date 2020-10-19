using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public Dictionary<string, Contact> contacts { get; set; }
        public int numberOfContacts { get; set; }

        public AddressBook()
        {
            this.contacts = new Dictionary<string, Contact>();
        }

        public void AddContact(Contact contact)
        {
            if (contacts.ContainsKey(contact.firstName))
            {
                Console.WriteLine("Contact Already Exists.");
                return;
            }
            contacts.Add(contact.firstName, contact);
            numberOfContacts = contacts.Count;
        }
        public void EditContact(string firstName, Contact contact)
        {
            
            if (firstName == contact.firstName)
                contacts[firstName] = contact;
            else
            {
                contacts.Remove(firstName);
                AddContact(contact);
            }

            Console.WriteLine("Contact Edited Successfully!");
        }

        public void DeleteContact(string firstName)
        {
            if (!contacts.ContainsKey(firstName))
            {
                Console.WriteLine("Input Contact Name does not exist.");
                return;
            }
            contacts.Remove(firstName);
            Console.WriteLine("Contact Deleted Successfully.");
        }

        public void SearchInCity(string firstName, string location)
        {

        }
    }
}
