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
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();

            List<Status> listPrjStatuses = projectStatusApi.GetHubProjectStatusList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Status status = new Status();
            status.Name = "AutoStatus";
            status.Color = "#FF0000";

            
            // TODO: This doesn't work, so update doesn't work and we can't really test delete.
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.CreateHubProjectStatus(hubId, projectId, status);
        }

        [Test]
        public void Test_UpdateProjectStatusCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int statusId = __GetProjectStatusRandom(hubId, projectId, "AutoStatus");
            
            Status status = new Status();
            status.Name = "UpdatedStatus";
            status.Color = "#FF0000";
            
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.UpdateHubProjectStatus(hubId, projectId, statusId,status);
        }

        [Test]
        public void Test_deleteProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int statusId = __GetProjectStatusRandom(hubId, projectId, "UpdatedStatus");
                        
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.DeleteHubProjectStatus(hubId, projectId, statusId);
        }

    }
}