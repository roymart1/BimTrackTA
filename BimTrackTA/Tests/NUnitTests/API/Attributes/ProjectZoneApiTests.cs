using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectZoneApiTests : GeneralTestBase
    {

        
        [Test]
        public void Test_GetProjectZoneList()
        {        
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();

            List<Zone> listPrjZones = projectZoneApi.GetHubProjectZoneList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            Zone zone = new Zone();
            zone.Name = "AutoProjectZoneTest";
            zone.Color = "#FF0000";

            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.CreateHubProjectZone(hubId, projectId, zone);
        }

        [Test]
        public void Test_UpdateProjectZoneCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "AutoProjectZoneTest");
            
            Zone zone = new Zone();
            zone.Name = "UpdatedProjectZoneTest";
            zone.Color = "#FF0000";
            
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.UpdateHubProjectZone(hubId, projectId, zoneId, zone);
        }

        [Test]
        public void Test_DeleteProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "UpdatedProjectZoneTest");
                        
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.DeleteHubProjectZone(hubId, projectId, zoneId);
        }
    }
}