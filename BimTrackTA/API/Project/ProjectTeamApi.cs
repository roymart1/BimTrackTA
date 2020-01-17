using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectTeamApi : ApiBase
    {
        
        public List<Team> GetHubProjectTeams(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + TEAM_ROUTE;
            return Perform_Get<List<Team>>(connStr);
        }

        public Team GetHubProjectTeam(int hubId, int projectId, int teamId)
        {
            List<Team> teams = GetHubProjectTeams(hubId, projectId);
            return Get_Object_From_List(teams, teamId);
        }
        
        
        public int CreateHubProjectTeam(int hubId, int projectId, Team team)
        {
            // Validate that the object is fine
            ValidateOperation(team);
            
            // Required fields for Team object are: 
            //     - Name (string)
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + TEAM_ROUTE;
            return Perform_Create(connStr, team);
        }
        
        public IRestResponse DeleteHubProjectTeam(int hubId, int projectId, int teamId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + TEAM_ROUTE + "/" +
                             teamId;            return Perform_Delete(connStr);
        }
        
               
        public List<User> GetHubProjectTeamUsers(int hubId, int projectId, int teamId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + TEAM_ROUTE + USER_ROUTE + "?teamId=" + teamId;
            return Perform_Get<List<User>>(connStr);
        }

        public bool UpdateHubProjectTeam(int hubId, int projectId, int teamId, Team team)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + TEAM_ROUTE + "/" +
                             teamId;
            
            IRestResponse response =  Perform_Update(connStr, team);
            return response.IsSuccessful;
        }

        private void ValidateOperation(Team team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            if (team.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project team");
            }
        }
    }
}