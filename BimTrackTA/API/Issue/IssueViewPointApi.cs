using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class IssueViewPointApi : ApiBase
    {
        public List<ViewPoint> GetIssueViewPointList(int hubId, int projectId, int issueId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + 
                             ISSUE_ROUTE + "/" + issueId + VIEWPOINT_ROUTE;
            return Perform_Get<List<ViewPoint>>(connStr);
        }

        public int CreateIssueViewPoint(int hubId, int projectId, int issueId, ViewPoint viewPoint, string imageName,
            string imagePath)
        {
            // Makes sure the object is correct
            ValidateOperation(imageName, viewPoint);

            // This is a special route, because you need both an image and a ViewPoint object. The image uses multipart
            // data, so you need to provide a filename and a filepath. The filename needs to end with .jpg, .jpeg, .gif
            // or .png.
            //
            // Required fields for ViewPoint object are: 
            //     - ViewType (string: 'None', 'TwoD' or 'ThreeD')
            //     - Source (string: 'Unspecified', 'Web', 'ThreeDViewer', 'BcfImport', 'WebApi', 'BcfWebApi', 
            //                       'Navisworks', 'Revit', 'Tekla' or 'AutoCad')
            //     - ViewName (string)
            //
            // CTRL+Click on ViewPoint for further details about the object's attributes
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" + issueId
                             + VIEWPOINT_ROUTE;
            return Perform_Create_Multipart(connStr, imageName, imagePath, viewPoint);
        }

        public ViewPoint GetIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" + issueId
                             + VIEWPOINT_ROUTE + "/" + viewPointId;
            return Perform_Get<ViewPoint>(connStr);
        }

        public bool DeleteIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" + issueId
                             + VIEWPOINT_ROUTE + "/" + viewPointId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }

        public bool UpdateIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId, ViewPoint viewPoint,
            string imageName, string imagePath)
        {
            // Validate that the image name is valid
            ValidateOperation(imageName);
            
            // This is weird too: even if we want to update the viewpoint object, we absolutely need to update the
            // picture as well. So you need to do the same thing as in create object. This could be changed in the
            // future since it doesn't appear to be a desired behavior.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" + issueId
                             + VIEWPOINT_ROUTE + "/" + viewPointId;
            IRestResponse response = Perform_Update_Multipart(connStr, imageName, imagePath, viewPoint);

            return response.IsSuccessful;
        }

        private void ValidateOperation(string imageName, ViewPoint viewPoint = null)
        {
            if (!FileIsImage(imageName))
            {
                throw new CustomObjectAttributeException(
                    "Your image name must contain one of these extensions: '.gif', '.png', '.jpg', '.jpeg'.");
            }

            if (viewPoint != null)
            {
                if (viewPoint.ViewType == null)
                {
                    throw new CustomObjectAttributeException("a ViewType", "issue viewpoint");
                }
                if (viewPoint.ViewType.ToLower() != "none" && viewPoint.ViewType.ToLower() != "twod" &&
                    viewPoint.ViewType.ToLower() != "threed")
                {
                    throw new CustomObjectAttributeException(
                        "Your ViewPoint ViewType must be one of these: 'None', 'TwoD' or 'ThreeD'.");
                }
                if (viewPoint.Source == null)
                {
                    throw new CustomObjectAttributeException("a source", "issue viewpoint");
                }
                if (viewPoint.Source.ToLower() != "unspecified" && viewPoint.Source.ToLower() != "web" &&
                    viewPoint.Source.ToLower() != "threedviewer" && viewPoint.Source.ToLower() != "bcfimport" &&
                    viewPoint.Source.ToLower() != "webapi" && viewPoint.Source.ToLower() != "bcfwebapi" &&
                    viewPoint.Source.ToLower() != "navisworks" && viewPoint.Source.ToLower() != "revit" &&
                    viewPoint.Source.ToLower() != "tekla" && viewPoint.Source.ToLower() != "autocad")
                {
                    throw new CustomObjectAttributeException(
                        "Your ViewPoint Source must be one of these: 'Unspecified', 'Web', 'ThreeDViewer', " +
                        "'BcfImport', 'WebApi', 'BcfWebApi', 'Navisworks', 'Revit', 'Tekla' or 'AutoCad'");
                }
                if (viewPoint.ViewName == null)
                {
                    throw new CustomObjectAttributeException("a ViewName", "issue viewpoint");
                }
            }
        }
    }
}