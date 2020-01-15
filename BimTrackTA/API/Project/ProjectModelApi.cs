using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectModelApi : ApiBase
    {
        public List<Model> GetProjectModelList(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE;
            return Perform_Get<List<Model>>(connStr);
        }

        public int CreateProjectModel(int hubId, int projectId, string modelName, string filePath, Model model=null)
        {
            // Validate that the object is fine
            ValidateOperation(model, modelName);
            
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .ifc or .ifczip.
            //
            // Required attributes for the model object are (if you are using it):
            //    - Name (string)
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE;
            return Perform_Create_Multipart(connStr, modelName, filePath, model);
        }
        
        public bool DeleteProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE + "/" + modelId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Model GetProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE + "/" + modelId;
            return Perform_Get<Model>(connStr);
        }

        public bool UpdateProjectModel(int hubId, int projectId, int modelId, int folderId)
        {
            string jsonToSend = "{'FolderId': " + folderId + "}";
            // CTRL+Click on Model for further information about that object.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + MODEL_ROUTE + "/" + modelId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }

        private void ValidateOperation(Model model, string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            // This treats the .ifczip case
            if (!fileName.Contains(".ifc"))
            {
                throw new CustomObjectAttributeException(
                    "Your model name must contain one of these extensions: '.ifc' or '.ifczip'.");
            }

            if (model != null)
            {
                if (model.Name == null)
                {
                    throw new CustomObjectAttributeException("a name", "project model");
                }
            }
        }
    }
}