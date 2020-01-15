using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectSheetFolderApi : ApiBase
    {
        public List<Folder> GetProjectSheetFolderList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders";
            return Perform_Get<List<Folder>>(connStr);
        }

        public int CreateProjectSheetFolder(int hubId, int projectId, Folder folder)
        {
            // Validate that the object is fine
            ValidateOperation(folder);
            
            // Required fields for Folder object are: 
            //     - Name (string)
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders";
            return Perform_Create(connStr, folder);
        }
        
        public bool DeleteProjectSheetFolder(int hubId, int projectId, int projectSheetFolderId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders/" + projectSheetFolderId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }
        
        public bool UpdateProjectSheetFolder(int hubId, int projectId, int projectSheetFolderId, Folder folder)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/sheets/folders/" + projectSheetFolderId;
            IRestResponse response = Perform_Update(connStr, folder);

            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Folder folder)
        {
            if (folder == null) throw new ArgumentNullException(nameof(folder));
            if (folder.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project sheet folder");
            }
        }
    }
}