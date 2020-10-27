using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AddressBookSystem
{
    [DataContract]
    class Address
    {
        [DataMember]
        public string addressLineOne { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public int zip { get; set; }
        public Address(string addressLineOne, string city, string state, int zip)
        {
            this.addressLineOne = addressLineOne;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public override string ToString()
        {
            return addressLineOne;
        }
    }
}
