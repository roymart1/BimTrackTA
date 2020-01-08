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
            int projectId = __GetProjectRandom(hubId);
            
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();

            List<Zone> listPrjZones = projectZoneApi.GetHubProjectZoneList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectZoneTest";

            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.CreateHubProjectZone(hubId, projectId, name);
            Assert.Pass();
        }

        [Test]
        public void Test_UpdateProjectZoneCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "AutoProjectZoneTest");

            string key = "Name";
            string value = "UpdatedProjectZoneTest";
            
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.UpdateHubProjectZone(hubId, projectId, zoneId, key, value);
            Assert.Pass();
        }

        [Test]
        public void Test_deleteProjectZone()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int zoneId = __GetProjectZoneRandom(hubId, projectId, "UpdatedProjectZoneTest");
                        
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            projectZoneApi.DeleteHubProjectZone(hubId, projectId, zoneId);
            Assert.Pass();
        }

    }
}