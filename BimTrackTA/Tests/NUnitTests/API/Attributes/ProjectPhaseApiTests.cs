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
        public void Test_CreateProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Phase phase = new Phase();
            phase.Name = "AutoPhase";
            phase.Color = "#FF0000";
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.CreateHubProjectPhase(hubId, projectId, phase);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectPhaseList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();

            List<Phase> listPrjPhases = projectPhaseApi.GetHubProjectPhaseList(hubId, projectId);
        }  
        
        [Test, Order(3)]
        public void Test_UpdateProjectPhaseCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "AutoPhase");

            Phase phase = new Phase();
            phase.Name = "UpdatedPhase";
            phase.Color = "#FF0000";
            
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.UpdateHubProjectPhase(hubId, projectId, phaseId, phase);
        }
        
        [Test, Order(4)]
        public void Test_DeleteProjectPhase()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int phaseId = __GetProjectPhaseRandom(hubId, projectId, "UpdatedPhase");
                        
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            projectPhaseApi.DeleteHubProjectPhase(hubId, projectId, phaseId);
        }

    }
}