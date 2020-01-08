using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectPhaseApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectPhaseList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();

            List<Phase> listPrjPhases = projectPhaseApi.GetHubProjectPhaseList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectPhaseTest";

            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.CreateHubProjectPhase(hubId, projectId, name);
        }

        [Test]
        public void Test_UpdateProjectPhaseCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "AutoProjectPhaseTest");

            string key = "Name";
            string value = "UpdatedProjectPhaseTest";
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.UpdateHubProjectPhase(hubId, projectId, phaseId, key, value);
        }

        [Test]
        public void Test_deleteProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "UpdatedProjectPhaseTest");
                        
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.DeleteHubProjectPhase(hubId, projectId, phaseId);
        }

    }
}