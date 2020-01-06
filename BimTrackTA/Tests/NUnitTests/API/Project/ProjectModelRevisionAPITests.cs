using System;
using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NLog;
using NLog.Targets;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectModelRevisionAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectModelRevisions()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            
            // Go on with the retrieval of the project list 
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            List<Revision> revisions = projectModelRevisionApi.GetProjectModelRevisionList(hubId, projectId, modelId);
        }

        [Test]
        public void Test_CreateProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            string name = "AutoRevision";
            
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            projectModelRevisionApi.CreateProjectModelRevision(hubId, projectId, modelId, name);
        }

        [Test]
        public void Test_DeleteProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            int revisionId = __GetProjectModelRevisionRandom(hubId, projectId, modelId);
            
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            projectModelRevisionApi.DeleteProjectModelRevision(hubId, projectId, modelId, revisionId);
        }
        
        [Test]
        public void Test_GetProjectModelRevision()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int modelId = __GetProjectModelRandom(hubId, projectId);
            int revisionId = __GetProjectModelRevisionRandom(hubId, projectId, modelId);

            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            Revision revision = projectModelRevisionApi.GetProjectModelRevision(hubId, projectId, modelId, revisionId);
        }
    }
}