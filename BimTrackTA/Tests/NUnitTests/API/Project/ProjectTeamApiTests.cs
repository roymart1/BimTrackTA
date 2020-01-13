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
        [Test, Order(1)]
        public void Test_CreateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");

            Team team = new Team {Name = "Ventilation3"};

            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.CreateHubProjectTeam(hubId, projectId, team);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectTeams()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<Team> prjUsers = projectApi.GetHubProjectTeams(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test_GetProjectTeamUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            int teamId = __GetTeamRandom(hubId, projectId, "Ventilation3");
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<User> listUser = projectApi.GetHubProjectTeamUsers(hubId, projectId, teamId);
            
        }

        [Test, Order(4)]
        public void Test_UpdateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            int teamId = __GetTeamRandom(hubId, projectId, "Ventilation3");

            Team team = new Team {Name = "UpdatedVentilation3"};

            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.UpdateHubProjectTeam(hubId, projectId, teamId, team);
        }
        
        [Test, Order(5)]
        public void Test_DeleteProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            int teamId = __GetTeamRandom(hubId, projectId, "UpdatedVentilation3");
            
            ProjectTeamApi projectTeamApi = new ProjectTeamApi();
            projectTeamApi.DeleteHubProjectTeam(hubId, projectId, teamId);
        }
    }
}