using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AddressBookDBTest
{
    public class ContactJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    [TestFixture]
    class RestSharpTests
    {
        List<ContactJson> contacts;
        RestClient client;
        private IRestResponse getContactList()
        {
            client = new RestClient("http://localhost:4000");
            var request = new RestRequest("contacts", Method.GET);
            var restResponse = client.Execute(request);
            contacts = JsonConvert.DeserializeObject<List<ContactJson>>(restResponse.Content);
            return restResponse;
        }
        [SetUp]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        [Test]
        public void OnCallingList_ReturnContacts()
        {
            var response = getContactList();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var dataResponse = JsonConvert.DeserializeObject<List<ContactJson>>(response.Content);
            Assert.AreEqual(1, dataResponse.Count);
            foreach (var contact in dataResponse)
                Console.WriteLine("Id : {0}, Name : {1}, Address : {2}", contact.Id, contact.Name, contact.Address);

        }
        /*
        [Test]
        public void GivenContact_OnUpdate_ShouldReturnAddedContacts()
        {

        }
        */

    }
}
