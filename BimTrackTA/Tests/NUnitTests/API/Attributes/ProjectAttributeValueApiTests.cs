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
            var prjAttr = new ProjectAttribute {Name = "ZenPredef", Type = "Predefined"};
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi(); 
            int attrValId = projectAttributeApi.CreateHubProjectAttribute(hubId, projectId, prjAttr);

            PredefinedAttributeValue prjCst = new PredefinedAttributeValue {Name = "zenUnknown", Color = "#550088"};
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
            prjAttrValApi.GetHubProjectAttributeValueList(hubId, projectId, attrValId);
        }

        [Test, Order(3)]
        public void Test_UpdateProjectAttributeValue()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int attrId = __GetHubProjectAttributeRandom(hubId, projectId, "ZenPredef");
            int attrValId = __GetHubProjectAttributeValueRandom(hubId, projectId, attrId, "zenUnknown");

            PredefinedAttributeValue predefinedAttributeValue = new PredefinedAttributeValue
            {
                Name = "UpdatedZenUnknown", Color = "#FF0000"
            };

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