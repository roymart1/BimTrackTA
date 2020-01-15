using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectModelRevisionApi : ApiBase
    {
        public List<Revision> GetProjectModelRevisionList(int hubId, int projectId, int modelId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId + "/revisions";
            return Perform_Get<List<Revision>>(connStr);
        }

        public int CreateProjectModelRevision(int hubId, int projectId, int modelId, string revisionName, string filePath)
        {
            // Validate that the revision name is fine
            ValidateOperation(revisionName);
            
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .ifc or .ifczip. A revision is basically another model object, so it works the same
            // way as the ProjectModelApi.
            //
            // Since you need a model id, that means that you need to have created a project in that hub first and
            // a model created in that project.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId + "/revisions";
            return Perform_Create_Multipart(connStr, revisionName, filePath);
        }
        
        public bool DeleteProjectModelRevision(int hubId, int projectId, int modelId, int revisionId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId  
                             + "/revisions/" + revisionId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Revision GetProjectModelRevision(int hubId, int projectId, int modelId, int revisionId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId 
                             + "/revisions/" + revisionId;
            return Perform_Get<Revision>(connStr);
        }

        private void ValidateOperation(string revisionName)
        {
            if (revisionName == null) throw new ArgumentNullException(nameof(revisionName));
            if (!revisionName.Contains(".ifc"))
            {
                throw new CustomObjectAttributeException(
                    "Your model revision name must contain one of these extensions: '.ifc' or '.ifczip'.");
            }
        }
    }
}