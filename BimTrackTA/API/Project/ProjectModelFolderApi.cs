using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectModelFolderApi : ApiBase
    {
        public List<Folder> GetProjectModelFolderList(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE +
                             FOLDER_ROUTE;     
            return Perform_Get<List<Folder>>(connStr);
        }

        public Folder GetProjectModelFolder(int hubId, int projectId, int folderId)
        {
            List<Folder> folders = GetProjectModelFolderList(hubId, projectId);
            return Get_Object_From_List(folders, folderId);
        }

        public int CreateProjectModelFolder(int hubId, int projectId, Folder folder)
        {
            // Validate that the object is fine
            ValidateOperation(folder);
            
            // Required fields for Folder object are: 
            //     - Name (string)
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE +
                             FOLDER_ROUTE;            
            return Perform_Create(connStr, folder);
        }
        
        public bool DeleteProjectModelFolder(int hubId, int projectId, int projectModelFolderId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE +
                             FOLDER_ROUTE + "/" + projectModelFolderId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }
        
        public bool UpdateProjectModelFolder(int hubId, int projectId, int projectModelFolderId, Folder folder)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE +
                             FOLDER_ROUTE + "/" + projectModelFolderId;
            IRestResponse response = Perform_Update(connStr, folder);

            return response.IsSuccessful;
        }

        private void ValidateOperation(Folder folder)
        {
            if (folder == null) throw new ArgumentNullException(nameof(folder));
            if (folder.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project model folder");
            }
        }
    }
}