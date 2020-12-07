using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using testapi.framework;

namespace testapi.tests.integration
{
    [TestClass]
    [TestCategory("Integration")]
    public class ServiceTests
    {
        private const string _uriString = "http://localhost:5000/api/players";

        [TestMethod]
        public async void WhenGETCalledThenReturnPlayers()
        {
            // could be run on a build process where the url is injected or retrieved from config
            HttpRequestMessage httpRequest = CreateRequest();
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient(CreateHandler()))
            {
                response = await client.SendAsync(httpRequest);
            }

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "StatusCode");
            Player[] parsedResponse = await ParseContentAsync<Player[]>(response.Content);
            Assert.AreEqual(3, parsedResponse.Length, "Players count");
        }

        private static HttpClientHandler CreateHandler()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            return clientHandler;
        }

        private static async Task<T> ParseContentAsync<T>(HttpContent httpContent)
        {
            T parsedContent;

            using (var reader = new StreamReader(await httpContent.ReadAsStreamAsync()))
            {
                string contentAsString = reader.ReadToEnd();
                parsedContent = JsonConvert.DeserializeObject<T>(contentAsString);
            }

            return parsedContent;
        }

        private static HttpRequestMessage CreateRequest()
        {
            return new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_uriString)
            };
        }
    }
}
