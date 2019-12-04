using System.Collections.Generic;
using BimTrackTA.API;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace BimTrackTA.Common.WebDriver
{
    public class GeneralTestBase
    {
        public GeneralTestBase()
        {
            CTX.SetKeyChainId();
        }
        
       protected int __GetHubRandom(string hubName = null)
        {
            HubAPI hubApiApi = new HubAPI();
            List<Hub> listHub = hubApiApi.GetHubList();
            if (hubName != null)
            {
                foreach (var hub in listHub)
                {
                    if (hub.Name.ToLower() == hubName.ToLower())
                    {
                        return hub.Id;
                    }
                }
            }
            // if none found the first one will be
            return listHub[0].Id;
        }

       protected int __GetProjectRandom(int hubId, string projectName = null)
        {
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
            if (projectName != null)
            {
                foreach (var project in listProject)
                {
                    if (project.Name.ToLower() == projectName.ToLower())
                    {
                        return project.Id;
                    }
                }
            }
            // if none found the first one will be
            return listProject[0].Id;
        }

       protected int __GetTeamRandom(int hubId, int projectId, string teamName=null)
        {
            ProjectTeamAPI projectApi = new ProjectTeamAPI();
            List<Team> listTeam = projectApi.GetHubProjectTeams(hubId, projectId);
            if (teamName != null)
            {
                foreach (var team in listTeam)
                {
                    if (team.Name.ToLower() == teamName.ToLower())
                    {
                        return team.Id;
                    }
                }
            }            
            
            return listTeam[0].Id;
        }
        
       protected int __GetUserRandom(int hubId, int projectId, string userEmail=null)
        {
            ProjectUserAPI projectApi = new ProjectUserAPI();
            List<ProjectUser> listUsers = projectApi.GetHubProjectUsers(hubId, projectId);
            if (userEmail != null)
            {
                foreach (var user in listUsers)
                {
                    if (user.User.Email.ToLower() == userEmail.ToLower())
                    {
                        return user.User.Id;
                    }
                }
            }            
            
            return listUsers[0].User.Id;
        }        
    }
}