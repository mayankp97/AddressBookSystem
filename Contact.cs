using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AddressBookSystem
{
    [DataContract]
    class Contact
    {
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public Address address { get; set; }
        [DataMember]
        public string phoneNumber { get; set; }
        [DataMember]
        public string email { get; set; }

        public Contact(string firstName, string lastName, Address address, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public override bool Equals(object obj) => firstName == (string)obj;

        public override string ToString() => firstName + " " + lastName;

    }
}
