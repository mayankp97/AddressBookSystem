using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Console_Message = "Please select an option : \n1.Add Contact\n2.Edit existing Contact\n3.Delete existing Contact\n4.Quit\nEnter your option :";

            Console.WriteLine("Welcome to Address Book System!");
            //Adding a contact to contact book
            var addressbook = new AddressBook();
            addressbook.AddContact(new Contact("A", "Raja",
                new Address("Bazar A", "Kolkata", "WB", 1452), "12345", "gmail.com"));

            bool quit = false;

            while (quit != true)
            {
                Console.Write(Console_Message);
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        var newContact = TakeInputForContact();
                        addressbook.AddContact(newContact);
                        break;
                    case 2:
                        //Editing by using first name of the contact
                        Console.Write("Enter the name of the person to edit contact details :");
                        var firstName = Console.ReadLine();

                        if (!addressbook.contacts.ContainsKey(firstName))
                            Console.WriteLine("No record(s) found");
                        else
                        {
                            var contactToEdit = addressbook.contacts[firstName];
                            Console.WriteLine("################ The existing details are ############");
                            DisplayContact(contactToEdit);
                            Console.WriteLine("################ Enter the new details ############");
                            var contact = TakeInputForContact();
                            addressbook.EditContact(firstName, contact);
                        }
                        break;
                    case 3:
                        //Deleting by using first name of the contact
                        Console.Write("Enter the name of the person to edit contact details :");
                        var firstNameToDelete = Console.ReadLine();
                        addressbook.DeleteContact(firstNameToDelete);
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }

            

            
            
        }

        static Contact TakeInputForContact()
        {
            Console.Write("Enter First Name : ");
            var firstName = Console.ReadLine();

            Console.Write("Enter Last Name : ");
            var lastName = Console.ReadLine();

            Console.Write("Enter Address Line One : ");
            var addressLineOne = Console.ReadLine();

            Console.Write("Enter City : ");
            var city = Console.ReadLine();

            Console.Write("Enter State : ");
            var state = Console.ReadLine();

            Console.Write("Enter Zip : ");
            var zip = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Phone No. : ");
            var phoneNumber = Console.ReadLine();

            Console.Write("Enter Email : ");
            var email = Console.ReadLine();

            var address = new Address(addressLineOne, city, state, zip);
            return new Contact(firstName, lastName, address, phoneNumber, email);
        }

        static void DisplayContact(Contact contact)
        {
            Console.WriteLine(" First Name : {0}",contact.firstName);
            Console.WriteLine(" Last Name : {0}",contact.lastName);
            Console.WriteLine(" Address Line One : {0}", contact.address.addressLineOne);
            Console.WriteLine(" City : {0}",contact.address.city);
            Console.WriteLine(" State : {0}",contact.address.state);
            Console.WriteLine(" Zip : {0}",contact.address.zip);
            Console.WriteLine(" Phone No. : {0}",contact.phoneNumber);
            Console.WriteLine(" Email : {0}",contact.email);
        }



    }
}
