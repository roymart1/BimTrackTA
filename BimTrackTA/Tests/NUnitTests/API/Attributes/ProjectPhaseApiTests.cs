using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectPhaseApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Phase phase = new Phase {Name = "AutoPhase", Color = "#FF0000"};
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.CreateProjectPhase(hubId, projectId, phase);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectPhaseList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.GetProjectPhases(hubId, projectId);
        }  
        
        [Test, Order(3)]
        public void Test3_UpdateProjectPhaseCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "AutoPhase", true);

            Phase phase = new Phase {Name = "UpdatedPhase", Color = "#FF0000"};
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.UpdateProjectPhase(hubId, projectId, phaseId, phase);
        }
        
        [Test, Order(4)]
        public void Test4_DeleteProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "UpdatedPhase", true);
                        
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.DeleteProjectPhase(hubId, projectId, phaseId);
        }
    }
}