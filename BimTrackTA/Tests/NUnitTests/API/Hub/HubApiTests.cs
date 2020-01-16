using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class HubApiTests : GeneralTestBase
    {
        
        [Test, Order(1)]
        public void Test1_GetHubList()
        {
            
            Console.Out.WriteLine("------------------- TEST START -----------------------");
            
            HubApi hubApiApi = new HubApi();
            List<Hub> listHub = hubApiApi.GetHubList();
            Assert.True(listHub.Count > 0, "No hub were found!");
            Console.Out.WriteLine("------------------- TEST END -----------------------");
        }
        
        [Test, Order(2)]
        public void Test2_GetHubInfo()
        {
            int hubId = __GetHubRandom();
            HubApi hubApiApi = new HubApi();
            hubApiApi.GetHub(hubId);
        }
    }
}