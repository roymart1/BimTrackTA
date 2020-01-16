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
        public void Test1_CreateProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            Zone zone = new Zone {Name = "AutoProjectZoneTest", Color = "#FF0000"};
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.CreateProjectZone(hubId, projectId, zone);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectZoneList()
        {        
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.GetProjectZones(hubId, projectId);
        }  
        
        [Test, Order(3)]
        public void Test3_UpdateProjectZoneCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "AutoProjectZoneTest", true);

            Zone zone = new Zone {Name = "UpdatedProjectZoneTest", Color = "#FF0000"};
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.UpdateProjectZone(hubId, projectId, zoneId, zone);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "UpdatedProjectZoneTest", true);
                        
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.DeleteProjectZone(hubId, projectId, zoneId);
        }
    }
}