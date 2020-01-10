using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionApiTests : GeneralTestBase
    {
        // We need to create a sheet first
        [Test]
        public void Setup_CreateProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            string sheetName = "AutoSheetForRevisionTest.pdf";
            string sheetPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.CreateProjectSheet(hubId, projectId, sheetName, sheetPath);
        }
        
        [Test]
        public void Test_GetProjectSheetRevisions()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest.pdf");
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            List<Revision> revisions = projectSheetRevisionApi.GetProjectSheetRevisionList(hubId, projectId, sheetId);
        }

        [Test]
        public void Test_CreateProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest.pdf");
            
            string revisionName = "AutoRevisionTest.pdf";
            string revisionPath = "../../../Tests/NUnitTests/API/TestResources/Sheet.pdf";
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.CreateProjectSheetRevision(hubId, projectId, sheetId, revisionName, revisionPath);
        }
        
        [Test]
        public void Test_GetProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoRevisionTest.pdf");

            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            Revision revision = projectSheetRevisionApi.GetProjectSheetRevision(hubId, projectId, sheetId, revisionId);
        }
        
        [Test]
        public void Test_DeleteProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest.pdf");
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId, "AutoRevisionTest.pdf");
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.DeleteProjectSheetRevision(hubId, projectId, sheetId, revisionId);
        }
        
        // Delete the sheet that we created
        [Test]
        public void End_DeleteProjectSheet()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int sheetId = __GetProjectSheetRandom(hubId, projectId, "AutoSheetForRevisionTest.pdf");
            
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            projectSheetApi.DeleteProjectSheet(hubId, projectId, sheetId);
        }
    }
}