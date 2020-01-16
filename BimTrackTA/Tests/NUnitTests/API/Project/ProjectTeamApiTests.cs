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
        public void Test1_CreateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Team team = new Team {Name = "Ventilation3"};

            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.CreateHubProjectTeam(hubId, projectId, team);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectTeams()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.GetHubProjectTeams(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test3_GetProjectTeamUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int teamId = __GetTeamRandom(hubId, projectId, "Ventilation3", true);
            
            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.GetHubProjectTeamUsers(hubId, projectId, teamId);
        }

        [Test, Order(4)]
        public void Test4_UpdateProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int teamId = __GetTeamRandom(hubId, projectId, "Ventilation3", true);

            Team team = new Team {Name = "UpdatedVentilation3"};

            ProjectTeamApi projectApi = new ProjectTeamApi();
            projectApi.UpdateHubProjectTeam(hubId, projectId, teamId, team);
        }
        
        [Test, Order(5)]
        public void Test5_DeleteProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int teamId = __GetTeamRandom(hubId, projectId, "UpdatedVentilation3", true);
            
            ProjectTeamApi projectTeamApi = new ProjectTeamApi();
            projectTeamApi.DeleteHubProjectTeam(hubId, projectId, teamId);
        }
    }
}