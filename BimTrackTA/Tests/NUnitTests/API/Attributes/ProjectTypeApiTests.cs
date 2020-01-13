using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectTypeApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            BimType bimType = new BimType {Name = "AutoProjectTypeTest", Color = "#FF0000"};

            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.CreateHubProjectType(hubId, projectId, bimType);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectTypeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();

            List<BimType> listPrjTypes = projectTypeApi.GetHubProjectTypeList(hubId, projectId);
        }    

        [Test, Order(3)]
        public void Test_UpdateProjectTypeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int typeId = __GetProjectTypeRandom(hubId, projectId, "AutoProjectTypeTest");

            BimType bimType = new BimType {Name = "UpdatedProjectTypeTest", Color = "#FF0000"};

            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.UpdateHubProjectType(hubId, projectId, typeId, bimType);
        }

        [Test, Order(4)]
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