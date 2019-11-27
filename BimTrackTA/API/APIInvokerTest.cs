using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class APIInvokerTest
    {
        public void TestCall()
        {
            // To be tested
            string szKey = "3d77a3ae21baa8f69021904db31b25d8103c98beac5df608a8fb96e2f10f6f62";
            // arrange
            RestClient client = new RestClient("https://api.bimtrackapp.co");
            client.AddDefaultHeader("Authorization", $"Bearer {szKey}");
            
            RestRequest request = new RestRequest("v2/hubs/", Method.GET);
            
            IRestResponse response = client.Execute(request);
 
            Console.Out.WriteLine("Done");
        }

    }
}