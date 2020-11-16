using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            /*
            //Retrieving Count by city
            AddressBookRepo.RetrieveContactsCountByCity();
            */
            /*
            //Adding one Contact
            var contactModel = new ContactModel { FirstName = "Iron", LastName = "Hulk", RelationType = "Father", DateAdded = DateTime.Now,
                Address = "starks", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "454545454", Email="@iron.com" };
            AddressBookRepo.AddContact(contactModel);
            */

            //Adding Multiple Contacts
            var contacts = new List<ContactModel> { new ContactModel { FirstName = "Captain", LastName = "America", RelationType = "Mom", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "454545454", Email="@cap.com" },
                new ContactModel { FirstName = "Hobes", LastName = "America", RelationType = "Sis", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "45454544", Email="@hobes.com" },
            new ContactModel { FirstName = "Hawkeye", LastName = "America", RelationType = "Bro", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "44545454", Email="@hawk.com" }};
            AddressBookRepo.AddMultipleContacts(contacts);


            
        }

        public static void AddMultiple()
        {
            var contacts = new List<ContactModel> { new ContactModel { FirstName = "Captain", LastName = "America", RelationType = "Mom", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "454545454", Email="@cap.com" },
                new ContactModel { FirstName = "Hobes", LastName = "America", RelationType = "Sis", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "45454544", Email="@hobes.com" },
            new ContactModel { FirstName = "Hawkeye", LastName = "America", RelationType = "Bro", DateAdded = DateTime.Now,
                Address = "Avenger Towers", State = "NY", City = "NYC", Zipcode = "45454", PhoneNumber = "44545454", Email="@hawk.com" }};

            foreach(var contact in contacts)
            {
                var thread = new Task(() => AddressBookRepo.AddContact(contact));
                thread.Start();
            }

        }
    }
}
