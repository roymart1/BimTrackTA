using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ApiBase
    {
        private readonly RestClient _client;


        protected ApiBase()
        {
            string szKey = CTX.keyChain.ApiKey;
            _client = new RestClient(CTX.keyChain.ApiUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            _client.AddDefaultHeader("Authorization", $"Bearer {szKey}");
        }
        
        private static void ProcessResponseError(IRestResponse response)
        {
            if (response.IsSuccessful != true)
            {
                JObject json = JObject.Parse(response.Content);
                JToken message = json["Message"];
                throw new BTException("Exception - Error Message: " + message + "\nFull error: " + json);
            }
        }
        
        private IRestResponse Execute_Post_Patch_Put_Request(string connectionStr, string jsonToSend, Method method)
        {
            RestRequest request = new RestRequest(connectionStr, method);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = _client.Execute(request);
            ProcessResponseError(response);
            return response;
        }

        protected IRestResponse Perform_Delete(string connectionStr)
        {
            var request = new RestRequest(connectionStr, Method.DELETE);
            IRestResponse response = _client.Execute(request);
            return response;
        }

        protected T Perform_Get<T>(string connectionStr)
        {
            RestRequest request = new RestRequest(connectionStr, Method.GET);
            IRestResponse response = _client.Execute(request);
            T listTemplates = JsonConvert.DeserializeObject<T>(response.Content);
            return listTemplates;
        }

        protected IRestResponse Perform_Create(string connectionStr, string jsonToSend)
        {
            return Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.POST);
        }
        
        protected IRestResponse Perform_Update(string connectionStr, string jsonToSend)
        {
            return Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.PUT);
        }

        protected IRestResponse Perform_Patch(string connectionStr, string jsonToSend)
        {
            return Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.PATCH);
        }

        protected IRestResponse Perform_Create_Multipart(string connectionStr, string fileName, string pathToFile,
            string metadata=null, Method method=Method.POST)
        {
            RestRequest request = new RestRequest(connectionStr, method);
            if (metadata != null)
            { 
                request.AlwaysMultipartFormData = true;
                request.AddParameter("metadata", metadata, "application/json", ParameterType.RequestBody);
            }

            Stream fs = File.OpenRead(pathToFile);
            request.AddFile(fileName, stream => fs.CopyTo(stream), fileName, fs.Length, "application/octet-stream");
            var response = _client.ExecuteTaskAsync(request, CancellationToken.None).Result;
            ProcessResponseError(response);
            return response;
        }

        protected IRestResponse Perform_Update_Multipart(string connectionStr, string fileName, string pathToFile,
            string metadata = null)
        {
            return Perform_Create_Multipart(connectionStr, fileName, pathToFile, metadata, Method.PUT);
        }
        
        protected string Create_UpdateJsonString(string key, object value)
        {
            if (value is string || value is char)
            {
                return "{'" + key + "': '" + value + "'}";
            }
            return "{'" + key + "': " + value + "}";
        }
    }
}