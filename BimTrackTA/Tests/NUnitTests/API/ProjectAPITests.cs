using System;
using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NLog;
using NLog.Targets;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectAPITests : GeneralTestBase
    {
        
        
        public ProjectAPITests()
        {
        
        }
        
        private int __GetHubRandom()
        {
            HubAPI hubApiApi = new HubAPI();
            List<Hub> listHub = hubApiApi.GetHubList();
            return listHub[0].Id;
        }

        private int __GetProjectRandom(int hubId)
        {
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
            return listProject[0].Id;
        }

        private int __GetTeamRandom(int hubId, int projectId)
        {
            ProjectAPI projectApi = new ProjectAPI();
            List<Team> listTeam = projectApi.GetHubProjectTeams(hubId, projectId);
            return listTeam[0].Id;
        }
        

        [Test]
        public void Test_GetHubProjectList()
        {
            int hubId = __GetHubRandom();
            
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
        }    
        
        
        [Test]
        public void Test_CreateHubProject()
        {
            int hubId = __GetHubRandom();
            
            // Go on with the retrieval of the project list / use templateId 0 for success
            ProjectAPI projectApi = new ProjectAPI();
            projectApi.CreateNewProject(hubId, 99, "AutoNewPrj");
        }

        [Test]
        public void Test_GetHubProjectUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectAPI projectApi = new ProjectAPI();
            // Call the get users from a specific project
            List<ProjectUser> prjUsers = projectApi.GetHubProjectUsers(hubId, projectId);
        }
        
        [Test]
        public void Test_GetHubProjectTeams()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            List<Team> prjUsers = projectApi.GetHubProjectTeams(hubId, projectId);
        }
        
        [Test]
        public void Test_CreateHubProjectTeam()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            projectApi.CreateHubProjectTeam(hubId, projectId, "Ventilation");
        }
        
        [Test]
        public void Test_GetHubProjectTeamUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId);
            
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectAPI();
            List<User> listUser = projectApi.GetHubProjectTeamUsers(hubId, projectId, teamId);
            
        }

        
    }
}