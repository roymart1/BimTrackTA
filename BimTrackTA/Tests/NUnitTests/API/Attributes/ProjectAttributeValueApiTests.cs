using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class ProjectAttributeValueApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create the project attribute before we can give it a value...
            var prjAttr = new ProjectAttribute();
            prjAttr.Name = "ZenPredef";
            prjAttr.Type = "Predefined";
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            bool bRet = projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);
            
            
            // Now, we can create the attribute value with the newly created attribute
            int attrValId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
            
            PredefinedAttributeValue prjCst = new PredefinedAttributeValue();
            prjCst.Name = "zenUnknown";
            prjCst.Color = "#550088";
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.CreateHubProjectAttributeValue(hubId, projectId, attrValId, prjCst);
        }
        
        [Test, Order(2)]
        public void Test_GetProjectAttributeValueList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrValId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();

            List<PredefinedAttributeValue> listAttrVal;
            listAttrVal = prjAttrValApi.GetHubProjectAttributeValueList(hubId, projectId, attrValId);
        }

        [Test, Order(3)]
        public void Test_UpdateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "zenUnknown");

            PredefinedAttributeValue predefinedAttributeValue = new PredefinedAttributeValue();
            predefinedAttributeValue.Name = "UpdatedZenUnknown";
            predefinedAttributeValue.Color = "#FF0000";
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi
                .UpdateHubProjectAttributeValue(hubId, projectId, attrId, attrValId, predefinedAttributeValue);
        }
        
        [Test, Order(4)]
        public void Test_DeleteProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "zenUnknown");
            
            ProjectAttributeValuesApi prjAttrValApi = new ProjectAttributeValuesApi();
            prjAttrValApi.DeleteHubProjectAttributeValue(hubId, projectId, attrId, attrValId);
            
            // Delete the attribute created in the first test
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            projectAttributeApi.DeleteHubProjectAttribute(hubId, projectId, attrId);
        }
    }
}