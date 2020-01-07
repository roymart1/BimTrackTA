using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectTeamApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectTeams()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<Project.Team> prjUsers = projectApi.GetHubProjectTeams(hubId, projectId);
        }
        
        
        [Test]
        public void Test_CreateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.CreateHubProjectTeam(hubId, projectId, "Ventilation2");
        }
                
        [Test]
        public void Test_GetProjectTeamUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId);
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<User> listUser = projectApi.GetHubProjectTeamUsers(hubId, projectId, teamId);
            
        }

        [Test]
        public void Test_UpdateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId);
            string key = "name";
            string newName = "UpdatedVentilation2";
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.UpdateHubProjectTeam(hubId, projectId, teamId, key, newName);
        }
        
        [Test]
        public void Test_DeleteProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId, "SammyLeeRock");
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            IRestResponse resRet = projectApi.DeleteHubProjectTeam(hubId, projectId, teamId);
            if (resRet.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Out.WriteLine("Failed to delete team " + teamId + " Reason == " + resRet.Content);
            }
        }
    }
}