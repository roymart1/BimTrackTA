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
        public void Test1_CreateProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            Priority priority = new Priority {Name = "AutoPriority", Color = "#FF0000"};
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.CreateProjectPriority(hubId, projectId, priority);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectPriorityList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.GetProjectPriorities(hubId, projectId);
        }   
        
        [Test, Order(3)]
        public void Test3_UpdateProjectPriorityCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "AutoPriority", true);

            Priority priority = new Priority {Name = "UpdatedPriority", Color = "#FF0000"};

            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.UpdateProjectPriority(hubId, projectId, priorityId, priority);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "UpdatedPriority", true);
                        
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.DeleteProjectPriority(hubId, projectId, priorityId);
        }
    }
}