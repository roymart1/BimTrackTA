using System.Collections.Generic;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class HubApi : ApiBase
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

