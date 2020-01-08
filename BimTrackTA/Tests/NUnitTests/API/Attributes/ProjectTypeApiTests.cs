using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectTypeApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectTypeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();

            List<BimType> listPrjTypes = projectTypeApi.GetHubProjectTypeList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            string name = "AutoProjectTypeTest";

            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.CreateHubProjectType(hubId, projectId, name);
        }

        [Test]
        public void Test_UpdateProjectTypeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int typeId = __GetProjectTypeRandom(hubId, projectId, "AutoProjectTypeTest");

            string key = "Name";
            string value = "UpdatedProjectTypeTest";
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.UpdateHubProjectType(hubId, projectId, typeId, key, value);
        }

        [Test]
        public void Test_deleteProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int typeId = __GetProjectTypeRandom(hubId, projectId, "UpdatedProjectTypeTest");
                        
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.DeleteHubProjectType(hubId, projectId, typeId);
        }

    }
}