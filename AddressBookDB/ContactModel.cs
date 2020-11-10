﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDB
{
    class ContactModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelationType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.Write(ContactId + " " + FirstName + " " + LastName + " " + RelationType + " " + Address
                + " " + City + " " + State + " " + Zipcode + " " + PhoneNumber + " " + Email+"\n");
        }

    }
}
