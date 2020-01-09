using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectSheetRevisionInstanceApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectSheetRevisionInstances()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            List<Instance> instances = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
        }

        [Test]
        public void Test_CreateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            
            Instance instance = new Instance();
            instance.ViewName = "AutoRevisionInstance";
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi
                .CreateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instance);
        }
        
        [Test]
        public void Test_GetProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            Instance instance = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instanceId);
        }

        [Test]
        public void Test_UpdateProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);

            Instance instance = new Instance();
            instance.ViewName = "UpdatedRevisionInstance";
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi.UpdateProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId,
                instanceId, instance);
        }
        
        [Test]
        public void Test_DeleteProjectSheetRevisionInstance()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int sheetId = __GetProjectSheetRandom(hubId, projectId);
            int revisionId = __GetProjectSheetRevisionRandom(hubId, projectId, sheetId);
            int instanceId = __GetProjectSheetRevisionInstanceRandom(hubId, projectId, sheetId, revisionId);
            
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            projectSheetRevisionInstanceApi
                .DeleteProjectSheetRevisionInstance(hubId, projectId, sheetId, revisionId, instanceId);
        }

    }
}