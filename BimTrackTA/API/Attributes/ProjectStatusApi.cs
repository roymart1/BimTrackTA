using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectStatusApi : ApiBase
    {
        public List<Status> GetProjectStatuses(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status";
            return Perform_Get<List<Status>>(connStr);
        }

        public int CreateProjectStatus(int hubId, int projectId, Status status)
        {
            // Required fields for Status object are: 
            //     - Name (string)
            //     - Color (hex format)
            //
            // CTRL+Click on Status for further details about the object's attributes
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status";
            return Perform_Create(connStr, status);
        }

        public bool DeleteProjectStatus(int hubId, int projectId, int statusId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status/" + statusId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectStatus(int hubId, int projectId, int statusId, Status status)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status/" + statusId;
            
            IRestResponse response = Perform_Update(connStr, status);
            return response.IsSuccessful;
        }
        
    }
}