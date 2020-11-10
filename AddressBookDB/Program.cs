using System;

namespace AddressBookDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddressBookRepo.RetrieveAllContacts();
            AddressBookRepo.DisplayContacts();
        }
    }
}
