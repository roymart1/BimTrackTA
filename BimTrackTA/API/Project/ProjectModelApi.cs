using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectModelApi : ApiBase
    {
        public List<Model> GetProjectModelList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models";
            return Perform_Get<List<Model>>(connStr);
        }

        public int CreateProjectModel(int hubId, int projectId, string modelName, string filePath)
        {
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .ifc or .ifczip.
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models";
            return Perform_Create_Multipart(connStr, modelName, filePath);
        }
        
        public bool DeleteProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Model GetProjectModel(int hubId, int projectId, int modelId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            return Perform_Get<Model>(connStr);
        }

        public bool UpdateProjectModel(int hubId, int projectId, int modelId, Model model)
        {
            // CTRL+Click on Model for further information about that object.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/models/" + modelId;
            IRestResponse response = Perform_Update(connStr, model);

            return response.IsSuccessful;
        }
    }
}