using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectSheetRevisionApi : ApiBase
    {
        public List<Revision> GetProjectSheetRevisionList(int hubId, int projectId, int sheetId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId + "/revisions";
            return Perform_Get<List<Revision>>(connStr);
        }

        public int CreateProjectSheetRevision(int hubId, int projectId, int sheetId, string revisionName, string revisionPath)
        {
            // Validate that the revision name is fine
            ValidateOperation(revisionName);
            
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .pdf. A revision is basically another sheet object, so it works the same
            // way as the ProjectSheetApi.
            //
            // Since you need a sheet id, that means that you need to have created a project in that hub first and
            // a sheet created in that project.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId + "/revisions";
            return Perform_Create_Multipart(connStr, revisionName, revisionPath);
        }
        
        public bool DeleteProjectSheetRevision(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId  
                             + "/revisions/" + revisionId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Revision GetProjectSheetRevision(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/sheets/" + sheetId 
                             + "/revisions/" + revisionId;
            return Perform_Get<Revision>(connStr);
        }
        
        private void ValidateOperation(string revisionName)
        {
            if (revisionName == null) throw new ArgumentNullException(nameof(revisionName));
            if (!revisionName.Contains(".pdf"))
            {
                throw new CustomObjectAttributeException(
                    "Your sheet revision name must be of the '.pdf' format.");
            }
        }
    }
}