using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectPriorityApi : ApiBase
    {
        public List<Priority> GetProjectPriorities(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PRIO_ROUTE;
            return Perform_Get<List<Priority>>(connStr);
        }

        public int CreateProjectPriority(int hubId, int projectId, Priority priority)
        {
            // Validate that the object is fine
            ValidateOperation(priority);
            
            // Required fields for Priority object are: 
            //     - Name (string)
            //     - Color (hex format)
            //
            // CTRL+Click on Priority for further details about the object's attributes
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PRIO_ROUTE;
            return Perform_Create(connStr, priority);
        }

        public bool DeleteProjectPriority(int hubId, int projectId, int priorityId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PRIO_ROUTE + "/" + priorityId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectPriority(int hubId, int projectId, int priorityId, Priority priority)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + PRIO_ROUTE + "/" + priorityId;
            
            IRestResponse response = Perform_Update(connStr, priority);
            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Priority priority)
        {
            if (priority == null) throw new ArgumentNullException(nameof(priority));
            if (priority.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project priority");
            }
            if (priority.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project priority");
            }
        }
    }
}