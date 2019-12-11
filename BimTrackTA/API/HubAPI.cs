using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace BimTrackTA.API
{
    public class HubAPI : APIBase
    {
        public List<Hub> GetHubList()
        {
            string connStr = "v2/hubs/";
            return Perform_Get<List<Hub>>(connStr);
        }
        
        public Hub GetHub(int hubId)
        {
            string connStr = "v2/hubs/" + hubId;
            return Perform_Get<Hub>(connStr);
        }

        
        
        
        


    }


}

