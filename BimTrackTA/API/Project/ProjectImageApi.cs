using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectImageApi : ApiBase
    {
        public int UpdateProjectImage(int hubId, int projectId, string fileName, string filePath)
        {
            // Since we are using Multipart, you need to provide a file name and a filepath. The file name needs
            // to end with .png, .jpg or .jpeg. Also, there is currently a problem: the image needs to be extremely
            // small, otherwise the graphical interface will load indefinitely. 
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/image";
            return Perform_Create_Multipart(connStr, fileName, filePath);
        }
    }
}