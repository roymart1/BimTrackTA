
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    
    public class HubUserAPI : APIBase
    {
        public enum UserType 
        {
            Guest = 1,
            Admin
        };
        
        
        public List<HubUser> GetHubUsers(int hubId)
        {
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/users", Method.GET);
            IRestResponse response = client.Execute(request);
            List<HubUser> listUsers = JsonConvert.DeserializeObject<List<HubUser>>(response.Content);
            return listUsers;
        }
        
        public bool CreateHubUser(int hubId, string email, UserType userType=UserType.Admin)
        {
            string jsonToSend = "{'Email': '" + email + "', 'Role': '" + userType.ToString() + "'}";
           
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/Users/", Method.POST);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            this.ProcessResponseError(response);
            return true;
        }

        public IRestResponse DeleteHubUser(int hubId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/users/" + userId;
            return Perform_Delete(connStr);
            
        }
    }
}