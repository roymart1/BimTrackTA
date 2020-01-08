using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetProjectAttributeList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();

            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);
        }    

        [Test]
        public void Test_GetProjectAttributeDetail()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);

            ProjectAttribute PrjAttributes = projectAttributeApi.GetHubProjectAttributeDetail(hubId, 
                projectId, listPrjAttributes[0].Id);
        }    
        
        [Test]
        public void Test_CreateProjectAttributePredefined()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            
            var prjAttr = new ProjectAttribute();
            prjAttr.Name = "ZenPredef";
            prjAttr.Type = "Predefined";
            prjAttr.AddNewCustomAttributeValue("xzenred", "#FF0000");
            prjAttr.AddNewCustomAttributeValue("xzengreen", "#00FF00");
            prjAttr.AddNewCustomAttributeValue("xzenblue", "#0000FF");
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.CreateHubProjectAttributeList(hubId, projectId, prjAttr);
        }
        
        
        [Test]
        public void Test_CreateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            
            var prjAttr = new ProjectAttribute();
            prjAttr.Name = "ZenCustom";
            prjAttr.Type = "Text";
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.CreateHubProjectAttributeList(hubId, projectId, prjAttr);
        }

        [Test]
        public void Test_UpdateProjectAttributeCustom()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenCustom");

            string key = "Name";
            string value = "UpdatedZenCustom";
            
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.UpdateHubProjectAttribute(hubId, projectId, attrId, key, value);
        }

        [Test]
        public void Test_deleteProjectAttribute()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "UpdatedZenCustom");
                        
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }

    }
}