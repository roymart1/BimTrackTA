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
        [Test, Order(1)]
        public void Test1_CreateProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int userId = __GetHubUserRandom(hubId, "bimoneauto+ki1120_013436@gmail.com", true);

            ProjectUser projectUser = new ProjectUser {UserId = userId, Role = "Reader"};

            ProjectUserApi projectUserApi = new ProjectUserApi();
            projectUserApi.CreateHubProjectUser(hubId, projectId, projectUser);
        }

        [Test, Order(2)]
        public void Test2_GetProjectUsers()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectUserApi projectApi = new ProjectUserApi();
            projectApi.GetHubProjectUsers(hubId, projectId);
        }
        
        [Test, Order(3)]
        public void Test3_UpdateProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int userId = __GetHubProjectUserRandom(hubId, projectId, "bimoneauto+ki1120_013436@gmail.com", true);

            ProjectUser user = new ProjectUser {Role = "Editor"};

            ProjectUserApi projectUserApi = new ProjectUserApi();
            projectUserApi.UpdateHubProjectUser(hubId, projectId, userId, user);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteProjectUser()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int userId = __GetHubProjectUserRandom(hubId, projectId, "bimoneauto+ki1120_013436@gmail.com", true);
            
            ProjectUserApi projectApi = new ProjectUserApi();
            projectApi.DeleteHubProjectUser(hubId, projectId, userId);
        }
    }
}