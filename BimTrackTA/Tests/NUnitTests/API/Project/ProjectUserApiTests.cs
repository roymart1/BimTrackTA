using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectUserApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectUserApi projectApi = new ProjectUserApi();
            // Call the get users from a specific project
            List<ProjectUser> prjUsers = projectApi.GetHubProjectUsers(hubId, projectId);
        }
        
        [Test]
        public void Test_DeleteProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int teamId = __GetUserRandom(hubId, projectId, "bimoneauto+ki1120_013436@gmail.com");
            
            // Go on with the retrieval of the project list 
            ProjectUserApi projectApi = new ProjectUserApi();
            IRestResponse resRet = projectApi.DeleteHubProjectUser(hubId, projectId, teamId);
            if (resRet.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Out.WriteLine("Failed to delete user " + teamId + " from project " 
                                      + projectId + " Reason == " + resRet.Content);
            }
        }

        [Test]
        public void Test_UpdateProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int userId = __GetUserRandom(hubId, projectId);

            string key = "FirstName";
            string value = "UpdatedUserTest";
            
            ProjectUserApi projectApi = new ProjectUserApi();
            projectApi.UpdateHubProjectUser(hubId, projectId, userId, key, value);
        }
    }
}