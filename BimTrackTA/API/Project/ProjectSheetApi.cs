using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectSheetApi : ApiBase
    {
        public List<Sheet> GetProjectSheetList(int hubId, int projectId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE;
            return Perform_Get<List<Sheet>>(connStr);
        }

        public int CreateProjectSheet(int hubId, int projectId, string sheetName, string sheetPath)
        {
            // Validate that the revision name is fine
            ValidateOperation(sheetName);
            
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .pdf
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE;
            return Perform_Create_Multipart(connStr, sheetName, sheetPath);
        }
        
        public bool DeleteProjectSheet(int hubId, int projectId, int sheetId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" + sheetId;
            IRestResponse response = Perform_Delete(connStr);
            
            return response.IsSuccessful;
        }

        public Sheet GetProjectSheet(int hubId, int projectId, int sheetId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + SHEET_ROUTE + "/" + sheetId;
            return Perform_Get<Sheet>(connStr);
        }

        private void ValidateOperation(string sheetName)
        {
            if (sheetName == null) throw new ArgumentNullException(nameof(sheetName));
            if (!sheetName.Contains(".pdf"))
            {
                throw new CustomObjectAttributeException(
                    "Your sheet name must be of the '.pdf' format.");
            }
        }
    }
}