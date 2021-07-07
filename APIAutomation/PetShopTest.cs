using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace APIAutomation
{
    public class PetShopTest
    {
        static string baseUri = "https://petstore.swagger.io/v2";


        [Test]
        public void FindPetByIdTest()
        {
            int petId = 99;
            string resource = "/pet/"+petId;

            RestClient client = new RestClient(baseUri);
            RestRequest request = new RestRequest(resource, Method.GET);
            var response= client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);

            Console.WriteLine(response.Content);


            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void FindPetByIdAndPrintNameTest()
        {
            int petId = 99;
            string resource = "/pet/" + petId;

            RestClient client = new RestClient(baseUri);
            RestRequest request = new RestRequest(resource, Method.GET);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);

            Console.WriteLine(response.Content);

            dynamic json= JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(json["id"]);
            Console.WriteLine(json["name"]);
            Console.WriteLine(json["category"]["name"]);

            Assert.AreEqual("doggie_kn", Convert.ToString(json["name"]));

        }

        [Test]
        public void FindPetByStatusTest()
        {
            string resource = "/pet/findByStatus";

            //baseuri
            RestClient client = new RestClient(baseUri);

            //requesttype,resource,queryparam,body
            RestRequest request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("status", "sold");

            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);

            Console.WriteLine(response.Content);
        }
    }
}