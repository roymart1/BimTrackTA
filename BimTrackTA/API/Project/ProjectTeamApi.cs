using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectTeamApi : ApiBase
    {
        
        public List<Team> GetHubProjectTeams(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams";
            return Perform_Get<List<Team>>(connStr);
        }
        
        
        public int CreateHubProjectTeam(int hubId, int projectId, Team team)
        {
            // Required fields for Team object are: 
            //     - Name (string)
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams";
            return Perform_Create(connStr, team);
        }
        
        public IRestResponse DeleteHubProjectTeam(int hubId, int projectId, int teamId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams/" + teamId;
            return Perform_Delete(connStr);
        }
        
               
        public List<User> GetHubProjectTeamUsers(int hubId, int projectId, int teamId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams/users?teamId=" + teamId;
            return Perform_Get<List<User>>(connStr);
        }

        public bool UpdateHubProjectTeam(int hubId, int projectId, int teamId, Team team)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams/" + teamId;
            
            IRestResponse response =  Perform_Update(connStr, team);
            return response.IsSuccessful;
        }
    }
}