using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectStatusApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Status status = new Status {Name = "AutoStatus", Color = "#FF0000"};
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.CreateProjectStatus(hubId, projectId, status);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectStatusList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.GetProjectStatuses(hubId, projectId);
        }

        [Test, Order(3)]
        public void Test3_UpdateProjectStatusCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int statusId = __GetProjectStatusRandom(hubId, projectId, "AutoStatus", true);

            Status status = new Status {Name = "UpdatedStatus", Color = "#FF0000"};
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.UpdateProjectStatus(hubId, projectId, statusId,status);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectStatus()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int statusId = __GetProjectStatusRandom(hubId, projectId, "UpdatedStatus", true);
                        
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            projectStatusApi.DeleteProjectStatus(hubId, projectId, statusId);
        }
    }
}