using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectPriorityApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectPriorityList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();

            List<Priority> listPrjPriorities = projectPriorityApi.GetHubProjectPriorityList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectPriorityTest";

            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.CreateHubProjectPriority(hubId, projectId, name);
        }

        [Test]
        public void Test_UpdateProjectPriorityCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "AutoProjectPriorityTest");

            string key = "Name";
            string value = "UpdatedProjectPriorityTest";
            
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.UpdateHubProjectPriority(hubId, projectId, priorityId, key, value);
        }

        [Test]
        public void Test_deleteProjectPriority()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int priorityId = __GetProjectPriorityRandom(hubId, projectId, "UpdatedProjectPriorityTest");
                        
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            projectPriorityApi.DeleteHubProjectPriority(hubId, projectId, priorityId);
        }

    }
}