using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectSheetRevisionInstanceApi : ApiBase
    {
        public List<Instance> GetProjectSheetRevisionInstanceList(int hubId, int projectId, int sheetId, int revisionId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" +
                             sheetId + REVISION_ROUTE + "/" + revisionId + INSTANCE_ROUTE;
            return Perform_Get<List<Instance>>(connStr);
        }

        public int CreateProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            Instance instance)
        {
            // Validate that the object is fine
            ValidateOperation(instance);
            
            // Required fields for Instance object are: 
            //     - CropBoxCenter (Xyz)
            //     - CropBoxRotation (Xyz)
            //     - CropBoxSize (Xyz)
            //     - Position (Xyz)
            //     - Rotation (Xyz)
            //
            // CTRL+Click on Instance for further details about the object's attributes
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" +
                             sheetId + REVISION_ROUTE + "/" + revisionId + INSTANCE_ROUTE;
            return Perform_Create(connStr, instance);
        }
        
        public bool DeleteProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            int instanceId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" +
                             sheetId + REVISION_ROUTE + "/" + revisionId + INSTANCE_ROUTE + "/" + instanceId;
            IRestResponse response =  Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Instance GetProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId, 
            int instanceId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" +
                             sheetId + REVISION_ROUTE + "/" + revisionId + INSTANCE_ROUTE + "/" + instanceId;
            return Perform_Get<Instance>(connStr);
        }

        public bool UpdateProjectSheetRevisionInstance(int hubId, int projectId, int sheetId, int revisionId,
            int instanceId, Instance instance)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" +
                             sheetId + REVISION_ROUTE + "/" + revisionId + INSTANCE_ROUTE + "/" + instanceId;
            IRestResponse response =  Perform_Update(connStr, instance);

            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Instance instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (instance.CropBoxCenter == null)
            {
                throw new CustomObjectAttributeException("a CropBoxCenter", "sheet's revision's instance");
            }
            if (instance.CropBoxRotation == null)
            {
                throw new CustomObjectAttributeException("a CropBoxRotation", "sheet's revision's instance");
            }
            if (instance.CropBoxSize == null)
            {
                throw new CustomObjectAttributeException("a CropBoxSize", "sheet's revision's instance");
            }
            if (instance.Position == null)
            {
                throw new CustomObjectAttributeException("a Position", "sheet's revision's instance");
            }
            if (instance.Rotation == null)
            {
                throw new CustomObjectAttributeException("a Rotation", "sheet's revision's instance");
            }
        }
    }
}