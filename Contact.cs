using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public Contact(string firstName, string lastName, Address address, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
