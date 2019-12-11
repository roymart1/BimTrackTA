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
    public class HubAPITests : GeneralTestBase
    {
        
        [Test]
        public void Test_GetHubList()
        {
            
            Console.Out.WriteLine("------------------- TEST START -----------------------");
            
            HubAPI hubApiApi = new HubAPI();
            List<Hub> listHub = hubApiApi.GetHubList();
            if (listHub.Count == 0) 
            { 
                throw new BTException("API Test: No hubs were found");
            }

            Hub hubObj = hubApiApi.GetHub(listHub[0].Id);
            Console.Out.WriteLine("------------------- TEST END -----------------------");
        }    
        
        [Test]
        public void Test_GetHubTemplates()
        {
            int hubId = __GetHubRandom();
            HubAPI hubApiApi = new HubAPI();
            List<ProjectTemplate> listTmpl = hubApiApi.GetHubProjectTemplates(hubId);
        }    
        
        [Test]
        public void Test_GetHubInfo()
        {
            int hubId = __GetHubRandom();
            HubAPI hubApiApi = new HubAPI();
            Hub hub = hubApiApi.GetHub(hubId);
        }           
        
        
    }
}