using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectUserApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            
            ProjectUserApi projectApi = new ProjectUserApi();
            // Call the get users from a specific project
            List<User> prjUsers = projectApi.GetHubProjectUsers(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            
            List<int> projectTeams = new List<int>();
            projectTeams.Add(0);
            
            ProjectUser user = new ProjectUser();
            user.UserId = 0;
            user.Role = "Reader";
            user.ProjectTeams = projectTeams;

            ProjectUserApi projectUserApi = new ProjectUserApi();
            projectUserApi.CreateHubProjectUser(hubId, projectId, user);
        }

        [Test]
        public void Test_UpdateProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoNewPrj");
            int userId = __GetUserRandom(hubId, projectId);

            ProjectUser user = new ProjectUser();
            user.Role = "Writer";    
            
            ProjectUserApi projectApi = new ProjectUserApi();
            projectApi.UpdateHubProjectUser(hubId, projectId, userId, user);
        }
        
        [Test]
        public void Test_DeleteProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetUserRandom(hubId, projectId, "bimoneauto+ki1120_013436@gmail.com");
            
            ProjectUserApi projectApi = new ProjectUserApi();
            IRestResponse resRet = projectApi.DeleteHubProjectUser(hubId, projectId, teamId);
            if (resRet.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Out.WriteLine("Failed to delete user " + teamId + " from project " 
                                      + projectId + " Reason == " + resRet.Content);
            }
        }
    }
}