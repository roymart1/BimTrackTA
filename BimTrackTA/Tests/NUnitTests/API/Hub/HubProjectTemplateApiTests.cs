using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class HubProjectTemplateApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test1_CreateHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject = projectApi.GetHubProjectList(hubId);

            ProjectTemplate projectTemplate = new ProjectTemplate
            {
                Name = "ZenAirport", SourceProjectId = listProject[1].Id
            };
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            int projectTemplateId = projectTemplateApi.CreateHubProjectTemplate(hubId, projectTemplate);

            // Make the assertion
            ProjectTemplate remoteProjectTemplate = projectTemplateApi.GetHubProjectTemplate(hubId, projectTemplateId);

            Assert.True(remoteProjectTemplate.Name == projectTemplate.Name,
                "Invalid project template name. Expected '" + projectTemplate.Name + "', got '" +
                remoteProjectTemplate.Name + "'.");
        }

        [Test, Order(2)]
        public void Test2_GetHubProjectTemplates()
        {
            int hubId = __GetHubRandom();
            ProjectTemplateApi prjtemplateApi = new ProjectTemplateApi();
            List<ProjectTemplate> projectTemplates = prjtemplateApi.GetHubProjectTemplates(hubId);

            // Make the assertion
            Assert.True(projectTemplates.Count > 0, "No project template found!");
        }

        [Test, Order(3)]
        public void Test3_DeleteHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            int prjTmplId = __GetHubProjectTemplateRandom(hubId, "ZenAirport", true);

            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            projectTemplateApi.DeleteHubProjectTemplate(hubId, prjTmplId);

            // Make the assertion
            List<ProjectTemplate> projectTemplates = projectTemplateApi.GetHubProjectTemplates(hubId);
            Assert.True(projectTemplates.Find(projectTemplate => projectTemplate.Id == prjTmplId) == null,
                "The project template has not really been deleted!");
        }
    }
}