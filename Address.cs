using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Address
    {
        public string addressLineOne { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }

        public Address(string addressLineOne, string city, string state, int zip)
        {
            this.addressLineOne = addressLineOne;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }
    }
}
