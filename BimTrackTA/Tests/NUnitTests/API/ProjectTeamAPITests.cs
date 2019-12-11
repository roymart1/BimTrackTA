
using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectTeamAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetHubProjectTeams()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectTeamAPI projectApi = new ProjectTeamAPI();
            List<Team> prjUsers = projectApi.GetHubProjectTeams(hubId, projectId);
        }

        [Test]
        public void Test_CreateHubProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectTeamAPI projectApi = new ProjectTeamAPI();
            projectApi.CreateHubProjectTeam(hubId, projectId, "Ventilation2");
        }
        
        [Test]
        public void Test_DeleteHubProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId, "SammyLeeRock");
            
            // Go on with the retrieval of the project list 
            ProjectTeamAPI projectApi = new ProjectTeamAPI();
            IRestResponse resRet = projectApi.DeleteHubProjectTeam(hubId, projectId, teamId);
            if (resRet.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Out.WriteLine("Failed to delete team " + teamId + " Reason == " + resRet.Content);
            }
        }
    }
}