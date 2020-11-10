using System;

namespace AddressBookDB
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Retrieving All Contacts
            Console.WriteLine("Hello World!");
            AddressBookRepo.RetrieveAllContacts();
            AddressBookRepo.DisplayContacts();
            */

            /*
            //Updating Contact
            var contact = AddressBookRepo.contacts[1];
            contact.LastName = "Sharma";
            AddressBookRepo.UpdateContact(contact);
            */

            /*
            //Retrieving Contacts in a date range
            var startDate = Convert.ToDateTime("01/01/2019");
            var endDate = Convert.ToDateTime("01/01/2020");
            AddressBookRepo.RetrieveAllContactsInDateRange(startDate, endDate);
            */

            //Retrieving Count by city
            AddressBookRepo.RetrieveContactsCountByCity();
            
        }
    }
}
