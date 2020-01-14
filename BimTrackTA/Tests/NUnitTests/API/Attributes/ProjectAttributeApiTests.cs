using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_GetProjectAttributeDetail()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);

            ProjectAttribute PrjAttributes = projectAttributeApi.GetHubProjectAttributeDetail(hubId, 
                projectId, listPrjAttributes[0].Id);
        }    
        
        [Test, Order(2)]
        public void Test_GetProjectAttributeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);
        }    

        [Test, Order(3)]
        public void Test_CreateProjectAttributePredefined()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");


            var prjAttr = new ProjectAttribute {Name = "ZenPredef", Type = "Predefined"};
            prjAttr.AddNewCustomAttributeValue("xzenred", "#FF0000");
            prjAttr.AddNewCustomAttributeValue("xzengreen", "#00FF00");
            prjAttr.AddNewCustomAttributeValue("xzenblue", "#0000FF");
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);
        }
        
        [Test, Order(4)]
        public void Test_CreateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");

            var prjAttr = new ProjectAttribute {Name = "ZenCustom", Type = "Text"};

            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);
        }

        [Test, Order(5)]
        public void Test_UpdateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenCustom");

            ProjectAttribute projectAttribute = new ProjectAttribute {Name = "UpdatedZenCustom", Type = "Text"};

            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.UpdateHubProjectAttribute(hubId, projectId, attrId, projectAttribute);
        }

        [Test, Order(6)]
        public void Test_DeleteProjectAttributePredef()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
                        
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }

        [Test, Order(7)]
        public void Test_DeleteProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "UpdatedZenCustom");
                        
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }
    }
}