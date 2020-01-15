using System.Collections.Generic;
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

        public int CreateHubUser(int hubId, string email, UserType userType=UserType.Admin)
        {
            // Pretty straightforward: send an email and a user type. The framework manages the rest.
            string jsonToSend = "{'Email': '" + email + "', 'Role': '" + userType + "'}";
            string connStr = "v2/hubs/" + hubId + "/users/";
            
            return Perform_Create(connStr, jsonToSend);
        }

        public bool DeleteHubUser(int hubId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/users/" + userId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public bool UpdateUser(int hubId, int userId, UserType userType, bool resendHubInvite=false)
        {
            string jsonToSend = "{'Role': '" + userType +
                                "', 'ResendHubInvite': " + resendHubInvite.ToString().ToLower() + "}";
            string connStr = "v2/hubs/" + hubId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}