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
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();

            List<BimType> listPrjTypes = projectTypeApi.GetHubProjectTypeList(hubId, projectId);
        }    
        
        [Test]
        public void Test_CreateProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            BimType bimType = new BimType();
            bimType.Name = "AutoProjectTypeTest";
            bimType.Color = "#FF0000";

            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.CreateHubProjectType(hubId, projectId, bimType);
        }

        [Test]
        public void Test_UpdateProjectTypeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int typeId = __GetProjectTypeRandom(hubId, projectId, "AutoProjectTypeTest");

            BimType bimType = new BimType();
            bimType.Name = "UpdatedProjectTypeTest";
            bimType.Color = "#FF0000";
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.UpdateHubProjectType(hubId, projectId, typeId, bimType);
        }

        [Test]
        public void Test_DeleteProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int typeId = __GetProjectTypeRandom(hubId, projectId, "UpdatedProjectTypeTest");
                        
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.DeleteHubProjectType(hubId, projectId, typeId);
        }

    }
}