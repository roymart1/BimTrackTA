using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

        protected const string API_VERSION = "v2";
        protected const string HUB_ROUTE = "/hubs";
        protected const string PROJ_ROUTE = "/projects";
        
        // Attributes
        protected const string ATTR_ROUTE = "/attributes";
        protected const string ATTR__VAL_ROUTE = "/attributevalues";
        protected const string DISCI_ROUTE = "/disciplines";
        protected const string PHASE_ROUTE = "/phases";
        protected const string PRIO_ROUTE = "/priorities";
        protected const string STATUS_ROUTE = "/status";
        protected const string TYPE_ROUTE = "/types";
        protected const string ZONE_ROUTE = "/zones";
        
        // Hub
        protected const string USER_ROUTE = "/users";
        protected const string PROJ_TEMP_ROUTE = "/projecttemplates";
        
        // Issue
        protected const string ISSUE_ROUTE = "/issues";
        protected const string ISSUE_ARCH_ROUTE = "/archivedissues";
        protected const string ATTACH_ROUTE = "/attachments";
        protected const string COMMENT_ROUTE = "/comments";
        protected const string VIEWPOINT_ROUTE = "/viewpoints";
        
        // Project
        protected const string IMG_ROUTE = "/image";
        protected const string MODEL_ROUTE = "/models";
        protected const string SHEET_ROUTE = "/sheets";
        protected const string FOLDER_ROUTE = "/folders";
        protected const string REVISION_ROUTE = "/revisions";
        protected const string INSTANCE_ROUTE = "/instances";
        protected const string TEAM_ROUTE = "/teams";
        
        protected ApiBase()
        {
            string szKey = CTX.keyChain.ApiKey;
            _client = new RestClient(CTX.keyChain.ApiUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            _client.AddDefaultHeader("Authorization", $"Bearer {szKey}");
        }
        
        private IRestResponse ProcessResponseError(IRestResponse response, IRestRequest request)
        {
            // If we have the "too many requests" problem
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                // Sleep for 2 seconds
                Thread.Sleep(2000);
                return Perform_Request(request);
            }
            if (response.IsSuccessful != true)
            {
                if (response.Content is string)
                {
                    throw new BTException("Exception - Error Message: " + response.Content);
                }
                JObject json = JObject.Parse(response.Content);
                JToken message = json["Message"];
                throw new BTException("Exception - Error Message: " + message + "\nFull error: " + json);
            }
            return response;
        }
        
        private IRestResponse Perform_Request(IRestRequest request)
        {
            var response = _client.Execute(request);
            var updatedResponse = ProcessResponseError(response, request);
            return updatedResponse;
        }
        
        private IRestResponse Perform_Request_Async(IRestRequest request)
        {
            var response = _client.ExecuteTaskAsync(request, CancellationToken.None).Result;
            var updatedResponse = ProcessResponseError(response, request);
            return updatedResponse;
        }

        private IRestResponse Create_And_Execute_Post_Patch_Put_Request(string connectionStr, string jsonToSend, Method method)
        {
            RestRequest request = new RestRequest(connectionStr, method);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return Perform_Request(request);
        }

        protected IRestResponse Perform_Delete(string connectionStr)
        {
            return Perform_Request(new RestRequest(connectionStr, Method.DELETE));
        }

        protected T Perform_Get<T>(string connectionStr)
        {
            IRestResponse response = Perform_Request(new RestRequest(connectionStr, Method.GET));
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        protected int Perform_Create(string connectionStr, object objectToSend)
        {
            string jsonToSend = Create_Json_Payload(objectToSend);
            IRestResponse response = Create_And_Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.POST);
            JObject json = JObject.Parse(response.Content);
            if (json != null)
            {
                if (json.ContainsKey("Id"))
                {
                    return (int)json["Id"];
                }

                if (json.ContainsKey("User"))
                {
                    return (int) json["User"]["Id"];
                }
            }
            throw new BTException("No id for object (test).");
        }
        
        protected IRestResponse Perform_Update(string connectionStr, object objectToSend)
        {
            string jsonToSend = Create_Json_Payload(objectToSend);
            return Create_And_Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.PUT);
        }

        protected IRestResponse Perform_Patch(string connectionStr, object objectToSend)
        {
            string jsonToSend = Create_Json_Payload(objectToSend);
            return Create_And_Execute_Post_Patch_Put_Request(connectionStr, jsonToSend, Method.PATCH);
        }
        
        private IRestResponse Execute_Multipart_Request(string connectionStr, string fileName, string pathToFile,
            object metadata = null, Method method = Method.POST)
        {
            RestRequest request = new RestRequest(connectionStr, method);
            if (metadata != null)
            { 
                string jsonToSend = Create_Json_Payload(metadata);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("metadata", jsonToSend, "application/json", ParameterType.RequestBody);
            }

            Stream fs = File.OpenRead(pathToFile);
            request.AddFile(fileName, stream => fs.CopyTo(stream), fileName, fs.Length, "application/octet-stream");

            return Perform_Request_Async(request);
        }

        protected int Perform_Create_Multipart(string connectionStr, string fileName, string pathToFile,
            object metadata=null, Method method=Method.POST)
        {
            IRestResponse response =
                Execute_Multipart_Request(connectionStr, fileName, pathToFile, metadata);
            try
            {
                JObject json = JObject.Parse(response.Content);
                if (json != null && json.ContainsKey("Id"))
                {
                    return (int) json["Id"];
                }
            }
            catch (JsonReaderException)
            {
                try
                {
                    JObject json = (JObject) JArray.Parse(response.Content).First;
                    if (json != null && json.ContainsKey("Id"))
                    {
                        return (int) json["Id"];
                    }
                }
                catch (Exception)
                {
                    Console.Write("The object created doesn't have an id.");
                }
            }
            return -1;
        }
        
        protected IRestResponse Perform_Update_Multipart(string connectionStr, string fileName, string pathToFile,
            object metadata = null)
        {
            return Execute_Multipart_Request(connectionStr, fileName, pathToFile, metadata, Method.PUT);
        }

        // This cannot be used for weird ids, such as HubUser/ProjectUser and sheet revisions
        protected T Get_Object_From_List<T>(List<T> objectList, int idToFind)
        {
            if (objectList.Count > 0)
            {
                foreach (dynamic obj in objectList)
                {
                    if (obj.Id != null && obj.Id == idToFind)
                    {
                        return obj;
                    }
                }
                throw new BTException("Requested id not found in the object's list: " + idToFind);
            }
            throw new Exception("Provided list is empty.");
        }
        
        private string Create_Json_Payload(object obj)
        {
            if (obj is string s)
            {
                return s;
            }
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                // If the value is null, don't add the attribute. The reason is that otherwise, objects initialized
                // with only a few attributes will always be "full of nulls" which is not considered to be a null
                // value for the API. It is considered as an attribute that has deliberately been set to null.
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        protected bool FileIsImage(string fileName)
        {
            return fileName.Contains(".jpg") || fileName.Contains(".jpeg") || fileName.Contains(".png") ||
                    fileName.Contains(".gif");
        }
    }
}