
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    
    public class HubUserApi : ApiBase
    {
        public enum UserType 
        {
            Guest = 1,
            Admin
        };


        public List<HubUser> GetHubUsers(int hubId)
        {
            string connStr = "v2/hubs/" + hubId + "/users";
            return Perform_Get<List<HubUser>>(connStr);
        }

        public bool CreateHubUser(int hubId, string email, UserType userType=UserType.Admin)
        {
            string jsonToSend = "{'Email': '" + email + "', 'Role': '" + userType.ToString() + "'}";
            string connStr = "v2/hubs/" + hubId + "/users/";
            
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;        }

        public bool DeleteHubUser(int hubId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/users/" + userId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public bool UpdateUser(int hubId, int userId, UserType userType, bool resendHubInvite)
        {
            string jsonToSend = "{'Role': '" + userType.ToString() +
                                "', 'ResendHubInvite': '" + resendHubInvite.ToString() + "'}";
            string connStr = "v2/hubs/" + hubId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}