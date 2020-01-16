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
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + USER_ROUTE;
            return Perform_Get<List<ProjectUser>>(connStr);
        }

        public int CreateHubProjectUser(int hubId, int projectId, ProjectUser user)
        {
            // Validate that the object is fine
            ValidateOperation(user);
            
            // Required fields for ProjectUser object are: 
            //     - User.Id (int)
            //     - Role ('Editor' or 'Reader')
            //
            // That means that first, you need to create a User object, give it the id of a real user using
            // __GetHubUserRandom([hubId], [email]) and then create a ProjectUser object with the new User
            // object as the User property and set a role for that ProjectUser.
            //
            // CTRL+Click on ProjectUser for further details about the object's attributes
            //
            // N.B. : If you receive the message 'the requested resource was not found', it's because your userId does
            // not correspond to a user that is present in your hub.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + USER_ROUTE;
            return Perform_Create(connStr, user);
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + USER_ROUTE + "/" + userId;
            return Perform_Delete(connStr);
        }

        public bool UpdateHubProjectUser(int hubId, int projectId, int userId, ProjectUser user)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + USER_ROUTE + "/" + userId;
            IRestResponse response = Perform_Update(connStr, user);

            return response.IsSuccessful;
        }

        private void ValidateOperation(ProjectUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.User == null)
            {
                throw new CustomObjectAttributeException("a user object", "project user");
            }
            if (user.User.Id == null)
            {
                throw new CustomObjectAttributeException("a user id", "project user's user object.");
            }
            if (user.Role.ToLower() != "editor" && user.Role.ToLower() != "reader")
            {
                throw new CustomObjectAttributeException("The role of your user needs to be 'Editor' or 'Reader'.");
            }
        }
    }
}