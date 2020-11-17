using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(4, dataResponse.Count);
            foreach (var contact in dataResponse)
                Console.WriteLine("Id : {0}, Name : {1}, Address : {2}", contact.Id, contact.Name, contact.Address);

        }
        
        [Test]
        public void GivenContact_OnPost_ShouldReturnAddedContacts()
        {
            var request = new RestRequest("contacts", Method.POST);
            var contact = new ContactJson { Name = "Lisa", Address = "address1" };

            var jObjectBody = new JObject();
            jObjectBody.Add("name", contact.Name);
            jObjectBody.Add("address", contact.Address);
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            var dataResponse = JsonConvert.DeserializeObject<ContactJson>(response.Content);
            Assert.AreEqual("Lisa", dataResponse.Name);
            Assert.AreEqual("address1", dataResponse.Address);

        }

        [Test]
        public void GivenContact_OnUpdate_ReturnsUpdatedContact()
        {
            var request = new RestRequest("contacts/1", Method.PUT);
            var contact = new ContactJson { Name = "Mr. Tomato", Address = "Tomato Farm" };

            var jObjectBody = new JObject();
            jObjectBody.Add("name", contact.Name);
            jObjectBody.Add("address", contact.Address);

            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            var response = client.Execute(request);
            

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var dataResponse = JsonConvert.DeserializeObject<ContactJson>(response.Content);
            Assert.AreEqual("Mr. Tomato", dataResponse.Name);
            Assert.AreEqual("Tomato Farm", dataResponse.Address);
            Console.WriteLine(response.Content);

        }
        [Test]
        public void GivenId_OnDelete_ShouldReturnSucessStatus()
        {
            var request = new RestRequest("contacts/2", Method.DELETE);

            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }
        

    }
}
