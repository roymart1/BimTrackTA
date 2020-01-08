using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectStatusApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectStatusList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();

            List<Status> listPrjStatuses = projectStatusApi.GetHubProjectStatusList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectStatusTest";

            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.CreateHubProjectStatus(hubId, projectId, name);
        }

        [Test]
        public void Test_UpdateProjectStatusCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int statusId = __GetProjectStatusRandom(hubId, projectId, "AutoProjectStatusTest");

            string key = "Name";
            string value = "UpdatedProjectStatusTest";
            
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.UpdateHubProjectStatus(hubId, projectId, statusId, key, value);
        }

        [Test]
        public void Test_deleteProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int statusId = __GetProjectStatusRandom(hubId, projectId, "UpdatedProjectStatusTest");
                        
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.DeleteHubProjectStatus(hubId, projectId, statusId);
        }

    }
}