using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);

            string sheetName = "AutoSheetTest.pdf";
            string sheetPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, sheetPath);
        }
        
        [Test, Order(2)]
        public void Test2_GetProjectSheets()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.GetProjectSheetList(hubId, projectId);
        }

        [Test, Order(3)]
        public void Test3_GetProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetTest", true);
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.GetProjectSheet(hubId, projectId, sheetId);
        }

        [Test, Order(4)]
        public void Test4_DeleteProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetTest", true);

            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }
    }
}