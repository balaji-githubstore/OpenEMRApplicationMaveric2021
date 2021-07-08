using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;

namespace APIAutomation
{
    public class PetShopTest
    {
        static string baseUri = "https://petstore.swagger.io/v2";

        [Test]
        public void FindPetByIdTest()
        {
            int petId = 997;
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

        [Test]
        public void AddPetRecordTest()
        {

            string resource = "/pet";

            var client = new RestClient(baseUri);
            var request = new RestRequest(resource, Method.POST);

            request.AddHeader("Content-Type", "application/json");
                            string body = @"{
                " + "\n" +
                            @"    ""id"": 998,
                " + "\n" +
                            @"    ""category"": {
                " + "\n" +
                            @"        ""id"": 0,
                " + "\n" +
                            @"        ""name"": ""string""
                " + "\n" +
                            @"    },
                " + "\n" +
                            @"    ""name"": ""doggie_xxxxx"",
                " + "\n" +
                            @"    ""photoUrls"": [
                " + "\n" +
                            @"        ""string""
                " + "\n" +
                            @"    ],
                " + "\n" +
                            @"    ""tags"": [
                " + "\n" +
                            @"        {
                " + "\n" +
                            @"            ""id"": 0,
                " + "\n" +
                            @"            ""name"": ""string""
                " + "\n" +
                            @"        }
                " + "\n" +
                            @"    ],
                " + "\n" +
                            @"    ""status"": ""available""
                " + "\n" +
                            @"}";

            //Console.WriteLine(body);

            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request); //send the request


            Console.WriteLine(response.Content);
        }

        [Test]
        public void AddPetRecordFromJsonTest()
        {

            string resource = "/pet";

            var client = new RestClient(baseUri);
            var request = new RestRequest(resource, Method.POST);

            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Authorization", "Bearer AAAAAAAAAAAAAAAAAAAAAAs5%2FAAAAAAA%2BFhxtLDRr2AuKh5zdIHTczhg0Jg%3DltF0dqGzLFlmXH9wjI8HkO1gEzGlnCYUegwIOVVu1Umn8Yi1sX");

            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Maveric 2021\OpenEMRApplication\APIAutomation\testdata\addrecord.json");
            string body = reader.ReadToEnd();

            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request); //send the request


            Console.WriteLine(response.Content);
        }

        [Test]
        public void UpdatePetRecordFromJsonTest()
        {

            string resource = "/pet";

            var client = new RestClient(baseUri);
            var request = new RestRequest(resource, Method.PUT);

            request.AddHeader("Content-Type", "application/json");


            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Maveric 2021\OpenEMRApplication\APIAutomation\testdata\addrecord.json");
            string body = reader.ReadToEnd();

            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request); //send the request


            Console.WriteLine(response.Content);
        }

        [Test]
        public void DeletePetRecordTest()
        {

            string resource = "/pet/997";

            var client = new RestClient(baseUri);
            var request = new RestRequest(resource, Method.DELETE);

            request.AddHeader("Content-Type", "application/json");


            IRestResponse response = client.Execute(request); //send the request


            Console.WriteLine(response.Content);
        }

    }
}