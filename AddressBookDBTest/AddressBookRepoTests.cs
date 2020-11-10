using AddressBookDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookDBTest
{
    [TestFixture]
    class AddressBookRepoTests
    {
        [Test]
        public void RetrieveAllContacts_WhenCalled_AddContactsToList()
        {
            AddressBookRepo.RetrieveAllContacts();

            var list = AddressBookRepo.contacts;

            Assert.That(list,Is.Not.Empty);
        }
        [Test]
        public void UpdateContact_WhenCalled_UpdateContactInDB()
        {
            AddressBookRepo.RetrieveAllContacts();

            var list = AddressBookRepo.contacts;
            var contact = list[1];
            var previousName = contact.FirstName;
            contact.FirstName = "Mahesh";
            AddressBookRepo.UpdateContact(contact);
            AddressBookRepo.contacts.Clear();
            AddressBookRepo.RetrieveAllContacts();
            var newName = AddressBookRepo.contacts.FirstOrDefault(c => c.ContactId == contact.ContactId).FirstName;


            Assert.That(previousName, Is.Not.EqualTo(newName));
        }
        [Test]
        public void RetrieveAllContactsInDateRange_WhenCalled_AddContactsToList()
        {
            var startDate = Convert.ToDateTime("01/01/2019");
            var endDate = Convert.ToDateTime("01/01/2020");
            AddressBookRepo.RetrieveAllContactsInDateRange(startDate, endDate);

            var list = AddressBookRepo.contacts;

            Assert.That(list, Is.Not.Empty);
        }
    }
}
