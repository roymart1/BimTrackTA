using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectPriorityApi : ApiBase
    {
        public List<Priority> GetProjectPriorities(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities";
            return Perform_Get<List<Priority>>(connStr);
        }

        public int CreateProjectPriority(int hubId, int projectId, Priority priority)
        {
            // Required fields for Priority object are: 
            //     - Name (string)
            //     - Color (hex format)
            //
            // CTRL+Click on Priority for further details about the object's attributes
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities";
            return Perform_Create(connStr, priority);
        }

        public bool DeleteProjectPriority(int hubId, int projectId, int priorityId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities/" + priorityId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectPriority(int hubId, int projectId, int priorityId, Priority priority)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities/" + priorityId;
            
            IRestResponse response = Perform_Update(connStr, priority);
            return response.IsSuccessful;
        }
        
    }
}