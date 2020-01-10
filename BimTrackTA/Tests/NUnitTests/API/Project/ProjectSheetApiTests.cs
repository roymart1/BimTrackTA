using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectSheets()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            List<Sheet> sheets = projectSheetApi.GetProjectSheetList(hubId, projectId);
        }

        [Test]
        public void Test_CreateProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            string sheetName = "AutoSheetTest.pdf";
            string sheetPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, sheetPath);
        }

        [Test]
        public void Test_GetProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetTest.pdf");
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.GetProjectSheet(hubId, projectId, sheetId);
        }

        [Test]
        public void Test_DeleteProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetTest.pdf");

            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }
    }
}