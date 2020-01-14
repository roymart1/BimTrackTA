using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueViewPointApi : ApiBase
    {
        public List<ViewPoint> GetIssueViewPointList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/viewpoints";
            return Perform_Get<List<ViewPoint>>(connStr);
        }

        public bool CreateIssueViewPoint(int hubId, int projectId, int issueId, ViewPoint viewPoint, string imageName, string imagePath)
        {
            // This is a special route, because you need both an image and a ViewPoint object. The image uses multipart
            // data, so you need to provide a filename and a filepath. The filename needs to end with .jpg, .jpeg or
            // .png.
            //
            // Required fields for ViewPoint object are: 
            //     - ViewType (string: 'None', 'TwoD' or 'ThreeD')
            //     - Source (string: 'Unspecified', 'Web', 'ThreeDViewer', 'BcfImport', 'WebApi', 'BcfWebApi', 
            //                       'Navisworks', 'Revit', 'Tekla' or 'AutoCad')
            //     - ViewName (string)
            //
            // CTRL+Click on ViewPoint for further details about the object's attributes
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/viewpoints";
            IRestResponse response =  Perform_Create_Multipart(connStr, imageName, imagePath,  viewPoint);
        
            return response.IsSuccessful;
        }

        public ViewPoint GetIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            return Perform_Get<ViewPoint>(connStr);
        }
        
        public bool DeleteIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }

        public bool UpdateIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId, ViewPoint viewPoint, 
            string imageName, string imagePath)
        {
            // This is weird too: even if we want to update the viewpoint object, we absolutely need to update the
            // picture as well. So you need to do the same thing as in create object. This could be changed in the
            // future since it doesn't appear to be a desired behavior.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Update_Multipart(connStr, imageName, imagePath, viewPoint);

            return response.IsSuccessful;
        }
    }
}

