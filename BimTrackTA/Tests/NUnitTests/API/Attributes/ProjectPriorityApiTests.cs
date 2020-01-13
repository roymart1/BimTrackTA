using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectPriorityApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            Priority priority = new Priority {Name = "AutoPriority", Color = "#FF0000"};

            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.CreateHubProjectPriority(hubId, projectId, priority);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectPriorityList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();

            List<Priority> listPrjPriorities = projectPriorityApi.GetHubProjectPriorityList(hubId, projectId);
        }   
        
        [Test, Order(3)]
        public void Test_UpdateProjectPriorityCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "AutoPriority");

            Priority priority = new Priority {Name = "UpdatedPriority", Color = "#FF0000"};

            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.UpdateHubProjectPriority(hubId, projectId, priorityId, priority);
        }

        [Test, Order(4)]
        public void Test_DeleteProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "UpdatedPriority");
                        
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.DeleteHubProjectPriority(hubId, projectId, priorityId);
        }
    }
}