using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ApiBase
    {
        protected RestClient client;


        public ApiBase()
        {
            string szKey = CTX.keyChain.ApiKey;
            client = new RestClient(CTX.keyChain.ApiUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            client.AddDefaultHeader("Authorization", $"Bearer {szKey}");
        }


        protected void ProcessResponseError(IRestResponse response)
        {
            if (response.IsSuccessful != true)
            {
                JObject json = JObject.Parse(response.Content);
                JToken message = json["Message"];
                throw new BTException("Exception - Error Message: " + message + "\nFull error: " + json);
            }
        }

        protected IRestResponse Perform_Delete(string connectionStr)
        {
            var request = new RestRequest(connectionStr, Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response;
        }

        protected T Perform_Get<T>(string connectionStr)
        {
            RestRequest request = new RestRequest(connectionStr, Method.GET);
            IRestResponse response = client.Execute(request);
            T listTemplates = JsonConvert.DeserializeObject<T>(response.Content);
            return listTemplates;
        }


        protected IRestResponse Perform_Create(string connectionStr, string jsonToSend)
        {
            RestRequest request = new RestRequest(connectionStr, Method.POST);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            ProcessResponseError(response);
            return response;
        }
        protected IRestResponse Perform_Update(string connectionStr, string jsonToSend)
        {
            RestRequest request = new RestRequest(connectionStr, Method.PUT);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            ProcessResponseError(response);
            return response;
        }

        protected IRestResponse Perform_Patch(string connectionStr, string jsonToSend)
        {
            RestRequest request = new RestRequest(connectionStr, Method.PATCH);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            ProcessResponseError(response);
            return response;
        }

        protected string Create_UpdateJsonString(string key, object value)
        {
            if (value is string || value is char)
            {
                return "{'" + key + "': '" + value + "'}";
            }

            return "{'" + key + "': " + value + "}";
        }

        protected IRestResponse Perform_Create_Multipart(string connectionStr, string fileName, string pathToFile,
            string metadata=null)
        {
            RestRequest request = new RestRequest(connectionStr, Method.POST);
            if (metadata != null)
            { 
                request.AlwaysMultipartFormData = true;
                request.AddParameter("metadata", metadata, "application/json", ParameterType.RequestBody);
            }

            Stream fs = File.OpenRead(pathToFile);
            request.AddFile(fileName, stream => fs.CopyTo(stream), fileName, fs.Length, "application/octet-stream");
            var response = client.ExecuteTaskAsync(request, CancellationToken.None).Result;
            ProcessResponseError(response);
            return response;
        }
    }
}