using System;
using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NLog;
using NLog.Targets;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectAPITests : GeneralTestBase
    {
        
        
        public ProjectAPITests()
        {
        
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
            
            ProjectUserAPI projectApi = new ProjectUserAPI();
            // Call the get users from a specific project
            List<ProjectUser> prjUsers = projectApi.GetHubProjectUsers(hubId, projectId);
        }
        
        [Test]
        public void Test_GetHubProjectTeamUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetTeamRandom(hubId, projectId);
            
            // Go on with the retrieval of the project list 
            ProjectAPI projectApi = new ProjectUserAPI();
            List<User> listUser = projectApi.GetHubProjectTeamUsers(hubId, projectId, teamId);
            
        }
        
        [Test]
        public void Test_DeleteHubProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetUserRandom(hubId, projectId, "bimoneauto+ki1120_013436@gmail.com");
            
            // Go on with the retrieval of the project list 
            ProjectUserAPI projectApi = new ProjectUserAPI();
            IRestResponse resRet = projectApi.DeleteHubProjectUser(hubId, projectId, teamId);
            if (resRet.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Out.WriteLine("Failed to delete user " + teamId + " from project " 
                                      + projectId + " Reason == " + resRet.Content);
            }
        }
        
        
        
    }
}