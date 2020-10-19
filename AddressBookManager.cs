using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookManager
    {
        public Dictionary<string, AddressBook> addressBooks;

        public Dictionary<string, List<Contact>> cityContactMap;

        public Dictionary<string, List<Contact>> stateContactMap;


        public AddressBookManager()
        {
            addressBooks = new Dictionary<string, AddressBook>();
            cityContactMap = new Dictionary<string, List<Contact>>();
            stateContactMap = new Dictionary<string, List<Contact>>();
        }

        public void AddToCityMap(Contact contact)
        {
            if (cityContactMap.ContainsKey(contact.address.city))
                cityContactMap[contact.address.city].Add(contact);
            else
                cityContactMap.Add(contact.address.city, new List<Contact> { contact });
        }

        public void AddToStateMap(Contact contact)
        {
            if (stateContactMap.ContainsKey(contact.address.city))
                stateContactMap[contact.address.city].Add(contact);
            else
                stateContactMap.Add(contact.address.city, new List<Contact> { contact });
        }

        public List<Contact> SearchInCity(string firstName,string city)
        {
            if (!cityContactMap.ContainsKey(city))
                return null;
            return cityContactMap[city].Where(C => C.firstName == firstName).ToList();
        }

        public List<Contact> SearchInState(string firstName, string state)
        {
            if (!cityContactMap.ContainsKey(state))
                return null;
            return stateContactMap[state].Where(C => C.firstName == firstName).ToList();
        }
    }
}
