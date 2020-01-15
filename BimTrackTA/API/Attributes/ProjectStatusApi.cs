using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

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
            // Validate that the object is fine
            ValidateOperation(status);
            
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
        
        private void ValidateOperation(Status status)
        {
            if (status == null) throw new ArgumentNullException(nameof(status));
            if (status.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project status");
            }
            if (status.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project status");
            }
        }
    }
}