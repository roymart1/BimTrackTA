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
        public void Test1_CreateProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            BimType bimType = new BimType {Name = "AutoProjectTypeTest", Color = "#FF0000"};
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.CreateProjectType(hubId, projectId, bimType);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectTypeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.GetProjectTypes(hubId, projectId);
        }    

        [Test, Order(3)]
        public void Test3_UpdateProjectTypeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int typeId = __GetProjectTypeRandom(hubId, projectId, "AutoProjectTypeTest", true);

            BimType bimType = new BimType {Name = "UpdatedProjectTypeTest", Color = "#FF0000"};
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.UpdateProjectType(hubId, projectId, typeId, bimType);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectType()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int typeId = __GetProjectTypeRandom(hubId, projectId, "UpdatedProjectTypeTest", true);
                        
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            projectTypeApi.DeleteProjectType(hubId, projectId, typeId);
        }
    }
}