using System;
using System.Collections.Generic;
using System.IO;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueAttachmentApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            // We need to create an issue for us to be able to create its attachment
            Issue issue = new Issue
            {
                Title = "IssueAttachmentTest",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            int issueId = issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that it's created, we can create its attachment 
            string fileName = "AutoAttachment.txt";
            string pathToAttachment = "../../../Tests/NUnitTests/API/TestResources/Attachment.txt";

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.CreateIssueAttachment(hubId, projectId, issueId, fileName, pathToAttachment);
        }

        [Test, Order(2)]
        public void Test2_GetIssueAttachmentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "IssueAttachmentTest", true);
            
            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.GetIssueAttachmentList(hubId, projectId, issueId);
        }  
        
        [Test, Order(3)]
        public void Test3_DeleteIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            int issueId = __GetIssueRandom(hubId, projectId, "IssueAttachmentTest", true);
            int attachmentId = __GetIssueAttachmentRandom(hubId, projectId, issueId, "AutoAttachment.txt", true);

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.DeleteIssueAttachment(hubId, projectId, issueId, attachmentId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);
        }
    }
}