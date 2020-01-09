using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectSheetRevisions()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            List<Revision> revisions = projectSheetRevisionApi.GetProjectSheetRevisionList(hubId, projectId, sheetId);
        }

        [Test]
        public void Test_CreateProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            
            Revision revision = new Revision();
            revision.Number = 10;
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.CreateProjectSheetRevision(hubId, projectId, sheetId, revision);
        }
        
        [Test]
        public void Test_GetProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);

            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            Revision revision = projectSheetRevisionApi.GetProjectSheetRevision(hubId, projectId, sheetId, revisionId);
        }
        
        [Test]
        public void Test_DeleteProjectSheetRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            projectSheetRevisionApi.DeleteProjectSheetRevision(hubId, projectId, sheetId, revisionId);
        }
    }
}