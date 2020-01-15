using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectZoneApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            Zone zone = new Zone {Name = "AutoProjectZoneTest", Color = "#FF0000"};
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.CreateProjectZone(hubId, projectId, zone);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectZoneList()
        {        
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.GetProjectZones(hubId, projectId);
        }  
        
        [Test, Order(3)]
        public void Test_UpdateProjectZoneCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "AutoProjectZoneTest");

            Zone zone = new Zone {Name = "UpdatedProjectZoneTest", Color = "#FF0000"};
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.UpdateProjectZone(hubId, projectId, zoneId, zone);
        }

        [Test, Order(4)]
        public void Test_DeleteProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "UpdatedProjectZoneTest");
                        
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.DeleteProjectZone(hubId, projectId, zoneId);
        }
    }
}