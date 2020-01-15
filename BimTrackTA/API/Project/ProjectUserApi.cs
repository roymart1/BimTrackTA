using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectUserApi : ApiBase
    {
        public List<ProjectUser> GetHubProjectUsers(int hubId, int projectId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Get<List<ProjectUser>>(connStr);
        }

        public int CreateHubProjectUser(int hubId, int projectId, ProjectUser user)
        {
            // Validate that the object is fine
            ValidateOperation(user);
            
            // Required fields for ProjectUser object are: 
            //     - UserId (int)
            //     - Role ('Editor' or 'Reader')
            //
            // CTRL+Click on ProjectUser for further details about the object's attributes
            //
            // N.B. : If you receive the message 'the requested resource was not found', it's because your userId does
            // not correspond to a user that is present in your hub.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Create(connStr, user);
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

        public bool UpdateHubProjectUser(int hubId, int projectId, int userId, ProjectUser user)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, user);

            return response.IsSuccessful;
        }

        private void ValidateOperation(ProjectUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Role == null)
            {
                throw new CustomObjectAttributeException("a role", "project user");
            }
            if (user.Role.ToLower() != "editor" && user.Role.ToLower() != "reader")
            {
                throw new CustomObjectAttributeException("The role of your user needs to be 'Editor' or 'Reader'.");
            }
        }
    }
}