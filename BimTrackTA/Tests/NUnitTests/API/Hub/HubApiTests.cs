using System;
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class HubApiTests : GeneralTestBase
    {
        
        [Test, Order(1)]
        public void Test_GetHubList()
        {
            
            Console.Out.WriteLine("------------------- TEST START -----------------------");
            
            HubApi hubApiApi = new HubApi();
            List<Hub> listHub = hubApiApi.GetHubList();
            if (listHub.Count == 0) 
            { 
                throw new BTException("API Test: No hubs were found");
            }

            hubApiApi.GetHub(listHub[0].Id);
            Console.Out.WriteLine("------------------- TEST END -----------------------");
        }
        
        [Test, Order(2)]
        public void Test_GetHubInfo()
        {
            int hubId = __GetHubRandom();
            HubApi hubApiApi = new HubApi();
            hubApiApi.GetHub(hubId);
        }
    }
}