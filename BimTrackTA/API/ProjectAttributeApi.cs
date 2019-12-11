
using System.Collections.Generic;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectAttributeApi : ApiBase
    {
        public List<ProjectAttribute> GetHubProjectTeams(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";
            return Perform_Get<List<ProjectAttribute>>(connStr);
        }
        
    }
}