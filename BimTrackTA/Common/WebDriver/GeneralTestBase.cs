using System;
using System.Collections.Generic;
using System.Linq;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace BimTrackTA.Common.WebDriver
{
    public class GeneralTestBase
    {
        public GeneralTestBase()
        {
            CTX.SetKeyChainId();
        }

        // This is a real ballsy meta-programming function that uses dynamics types and a bunch of other
        // shenanigans. Be aware that although I've manged to make it work when we need to compare objects
        // that have depth (user.User.Email) for example, I've decided to remove this functionality because
        // it is starting to be hard to manage for no real plus-value.
        private int __findSpecificObject<T>(List<T> objectList, string usedProperty = null, 
            string valueToCompareTo = null, bool needToFind = false)
        {
            // Get the string value of the object inside the list and remove Bim to change BimComment to Comment.
            string objectName = objectList.GetType().GenericTypeArguments.Single().Name.Replace("Bim", "");
            if (objectList.Count > 0)
            {
                if (valueToCompareTo != null)
                {
                    foreach (dynamic obj in objectList)
                    {
                        var valueOfRemoteObject = obj.GetType().GetProperty(usedProperty).GetValue(obj, null);
                        if (valueOfRemoteObject != null && valueOfRemoteObject.ToLower() == valueToCompareTo.ToLower())
                        {
                            if (obj.Id != null)
                            {
                                return obj.Id;
                            }
                        }
                    }
                    // We did not find the specified object. If we want to make an error, the assertion
                    // will raise if needToFind is true. Otherwise, it will simply print the warning message.
                    Assert.False(needToFind, "The specified " + objectName + " was not found: " + valueToCompareTo);
                    Console.Write("The specified " + objectName + " was not found: " + valueToCompareTo);
                }
                if (((dynamic) objectList[0]).Id != null)
                {
                    return ((dynamic) objectList[0]).Id;
                }
            }
            throw new Exception("No " + objectName + " found in the specified context.");
        }


        protected int __GetHubRandom(string hubName = null, bool needToFind = false)
        {
            HubApi hubApiApi = new HubApi();
            List<Hub> listHub = hubApiApi.GetHubList();
            
            return __findSpecificObject(
                listHub,
                "Name",
                hubName,
                needToFind
            );
        }

        protected int __GetProjectRandom(int hubId, string projectName = null, bool needToFind = false)
        {
            // Go on with the retrieval of the project list 
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject = projectApi.GetHubProjectList(hubId);

            return __findSpecificObject(
                listProject,
                "Name",
                projectName,
                needToFind
            );
        }

        protected int __GetTeamRandom(int hubId, int projectId, string teamName = null, bool needToFind = false)
        {
            ProjectTeamApi projectApi = new ProjectTeamApi();
            List<Team> listTeam = projectApi.GetHubProjectTeams(hubId, projectId);

            return __findSpecificObject(
                listTeam,
                "Name",
                teamName,
                needToFind
            );
        }

        protected int __GetHubProjectUserRandom(int hubId, int projectId, string userEmail = null, bool needToFind = false)
        {
            ProjectUserApi projectApi = new ProjectUserApi();
            List<ProjectUser> listUsers = projectApi.GetHubProjectUsers(hubId, projectId);

            if (listUsers.Count > 0)
            {
                if (userEmail != null)
                {
                    foreach (ProjectUser user in listUsers)
                    {
                        if (user.User.Email.ToLower() == userEmail.ToLower())
                        {
                            if (user.User.Id != null)
                            {
                                return (int) user.User.Id;
                            }
                        }
                    }
                    // We did not find the specified user. If we want to make an error, the assertion
                    // will raise if needToFind is true. Otherwise, it will simply print the warning message.
                    Assert.False(needToFind, "The specified project user was not found: " + userEmail);
                    Console.Write("The specified user was not found: " + userEmail);
                }

                var userId = listUsers[0].UserId;
                if (userId != null) return (int) userId;
            }
            throw new Exception("No user found for that project: " + projectId);
        }

        protected int __GetHubUserRandom(int hubId, string userEmail = null, bool needToFind = false)
        {
            HubUserApi hubUserApi = new HubUserApi();
            List<HubUser> listUsers = hubUserApi.GetHubUsers(hubId);
            
            if (listUsers.Count > 0)
            {
                if (userEmail != null)
                {
                    foreach (HubUser user in listUsers)
                    {
                        if (user.User.Email.ToLower() == userEmail.ToLower())
                        {
                            if (user.User.Id != null)
                            {
                                return (int) user.User.Id;
                            }
                        }
                    }
                    // We did not find the specified user. If we want to make an error, the assertion
                    // will raise if needToFind is true. Otherwise, it will simply print the warning message.
                    Assert.False(needToFind, "The specified project user was not found: " + userEmail);
                    Console.Write("The specified project user was not found: " + userEmail);
                }

                var userId = listUsers[0].User.Id;
                if (userId != null) return (int) userId;
            }
            throw new Exception("No user found in that hub: " + hubId);
        }

        protected int __GetHubProjectTemplateRandom(int hubId, string tmplName = null, bool needToFind = false)
        {
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            List<ProjectTemplate> listPrjTemplates = projectTemplateApi.GetHubProjectTemplates(hubId);

            return __findSpecificObject(
                listPrjTemplates,
                "Name",
                tmplName,
                needToFind
            );
        }

        protected int __GetHubProjectAttributeRandom(int hubId, int projectId, string attrName = null,
            bool needToFind = false)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            List<ProjectAttribute> listPrjAttributes = projectAttributeApi.GetHubProjectAttributeList(hubId, projectId);

            return __findSpecificObject(
                listPrjAttributes,
                "Name",
                attrName,
                needToFind
            );
        }

        protected int __GetHubProjectAttributeValueRandom(int hubId, int projectId, int attrId,
            string attrValName = null, bool needToFind = false)
        {
            ProjectAttributeApi projectAttributeApi = new ProjectAttributeApi();
            ProjectAttribute prjAttribute =
                projectAttributeApi.GetHubProjectAttributeDetail(hubId, projectId, attrId);
            
            return __findSpecificObject(
                prjAttribute.ProjectCustomAttributeValues,
                "Name",
                attrValName,
                needToFind
            );
        }

        protected int __GetProjectModelRandom(int hubId, int projectId, string modelName = null,
            bool needToFind = false)
        {
            // IMPORTANT: The model name is the name of the file that has been sent, not the name of the model object.
            ProjectModelApi projectModelApi = new ProjectModelApi();
            List<Model> listModels = projectModelApi.GetProjectModelList(hubId, projectId);
            
            return __findSpecificObject(
                listModels,
                "Name",
                modelName,
                needToFind
            );
        }

        protected int __GetProjectModelFolderRandom(int hubId, int projectId, string modelFolderName = null,
            bool needToFind = false)
        {
            ProjectModelFolderApi projectModelFolderApi = new ProjectModelFolderApi();
            List<Folder> listFolders = projectModelFolderApi.GetProjectModelFolderList(hubId, projectId);
            
            return __findSpecificObject(
                listFolders,
                "Name",
                modelFolderName,
                needToFind
            );
        }

        protected int __GetProjectModelRevisionRandom(int hubId, int projectId, int modelId, string fileName = null,
            bool needToFind = false)
        {
            ProjectModelRevisionApi projectModelRevisionApi = new ProjectModelRevisionApi();
            List<ModelRevision> listRevisions = projectModelRevisionApi
                .GetProjectModelRevisionList(hubId, projectId, modelId);
            
            return __findSpecificObject(
                listRevisions,
                "Name",
                fileName,
                needToFind
            );
        }

        protected int __GetProjectSheetRandom(int hubId, int projectId, string sheetName = null,
            bool needToFind = false)
        {
            ProjectSheetApi projectSheetApi = new ProjectSheetApi();
            List<Sheet> listSheets = projectSheetApi.GetProjectSheetList(hubId, projectId);
                    
            return __findSpecificObject(
                listSheets,
                "Name",
                sheetName,
                needToFind
            );
        }

        protected int __GetProjectSheetFolderRandom(int hubId, int projectId, string sheetFolderName = null,
            bool needToFind = false)
        {
            ProjectSheetFolderApi projectSheetFolderApi = new ProjectSheetFolderApi();
            List<Folder> listFolders = projectSheetFolderApi.GetProjectSheetFolderList(hubId, projectId);

            return __findSpecificObject(
                listFolders,
                "Name",
                sheetFolderName,
                needToFind
            );
        }

        protected int __GetProjectSheetRevisionRandom(int hubId, int projectId, int sheetId, string fileName = null,
            bool needToFind = false)
        {
            ProjectSheetRevisionApi projectSheetRevisionApi = new ProjectSheetRevisionApi();
            List<SheetRevision> listRevisions = projectSheetRevisionApi
                .GetProjectSheetRevisionList(hubId, projectId, sheetId);

            if (listRevisions.Count > 0)
            {
                if (fileName != null)
                {
                    foreach (var revision in listRevisions)
                    {
                        if (revision.FileInfo.Name.ToLower() == fileName.ToLower())
                        {
                            if (revision.Id != null)
                            {
                                return (int) revision.Id;
                            }
                        }
                    }
                    // We did not find the specified revision. If we want to make an error, the assertion
                    // will raise if needToFind is true. Otherwise, it will simply print the warning message.
                    Assert.False(needToFind, "Error: the specified sheet revision was not found: " + fileName);
                    Console.WriteLine("Warning: the specified sheet revision was not found: " + fileName);
                }

                var id = listRevisions[0].Id;
                if (id != null) return (int) id;
            }
            throw new Exception("There is no revision for that sheet: " + sheetId);
        }

        protected int __GetProjectSheetRevisionInstanceRandom(int hubId, int projectId, int sheetId, int revisionId,
            string viewName = null, bool needToFind = false)
        {
            ProjectSheetRevisionInstanceApi projectSheetRevisionInstanceApi = new ProjectSheetRevisionInstanceApi();
            List<Instance> listInstance = projectSheetRevisionInstanceApi
                .GetProjectSheetRevisionInstanceList(hubId, projectId, sheetId, revisionId);
       
            return __findSpecificObject(
                listInstance,
                "ViewName",
                viewName,
                needToFind
            );
        }

        protected int __GetIssueRandom(int hubId, int projectId, string issueTitle = null, bool needToFind = false)
        {
            IssueApi issueApi = new IssueApi();
            List<Issue> listIssues = issueApi.GetIssueList(hubId, projectId);

            return __findSpecificObject(
                listIssues,
                "Title",
                issueTitle,
                needToFind
            );
        }

        protected int __GetArchivedIssueRandom(int hubId, int projectId, string issueTitle = null,
            bool needToFind = false)
        {
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            List<Issue> listArchivedIssues = issueArchivedApi.GetIssueArchivedList(hubId, projectId);

            return __findSpecificObject(
                listArchivedIssues,
                "Title",
                issueTitle,
                needToFind
            );
        }

        protected int __GetIssueAttachmentRandom(int hubId, int projectId, int issueId, string attachmentName = null,
            bool needToFind = false)
        {
            IssueAttachmentApi issueAttachmentApi = new IssueAttachmentApi();

            List<Issue.Attachment> listIssueAttachments = issueAttachmentApi
                .GetIssueAttachmentList(hubId, projectId, issueId);

            return __findSpecificObject(
                listIssueAttachments,
                "Name",
                attachmentName,
                needToFind
            );
        }

        protected int __GetIssueCommentRandom(int hubId, int projectId, int issueId, string commentValue = null,
            bool needToFind = false)
        {
            IssueCommentApi issueCommentApi = new IssueCommentApi();
            List<BimComment> listIssueComments = issueCommentApi
                .GetIssueCommentList(hubId, projectId, issueId);

            return __findSpecificObject(
                listIssueComments,
                "Comment",
                commentValue,
                needToFind
            );
        }

        protected int __GetIssueViewPointRandom(int hubId, int projectId, int issueId, string viewName = null,
            bool needToFind = false)
        {
            IssueViewPointApi issueViewPointApi = new IssueViewPointApi();

            List<ViewPoint> listIssueViewPoints = issueViewPointApi
                .GetIssueViewPointList(hubId, projectId, issueId);

            return __findSpecificObject(
                listIssueViewPoints,
                "ViewName",
                viewName,
                needToFind
            );
        }

        protected int __GetIssueViewPointCommentRandom(int hubId, int projectId, int issueId, int viewPointId,
            string commentValue = null, bool needToFind = false)
        {
            IssueViewPointCommentApi issueViewPointCommentApi = new IssueViewPointCommentApi();
            List<BimComment> listIssueViewPointComments = issueViewPointCommentApi
                .GetIssueViewPointCommentList(hubId, projectId, issueId, viewPointId);
            
            return __findSpecificObject(
                listIssueViewPointComments,
                "Comment",
                commentValue,
                needToFind
            );
        }

        protected int __GetProjectDisciplineRandom(int hubId, int projectId, string name = null,
            bool needToFind = false)
        {
            ProjectDisciplineApi projectDisciplineApi = new ProjectDisciplineApi();
            List<Discipline> listProjectDisciplines = projectDisciplineApi
                .GetProjectDisciplines(hubId, projectId);

            return __findSpecificObject(
                listProjectDisciplines,
                "Name",
                name,
                needToFind
            );
        }

        protected int __GetProjectPhaseRandom(int hubId, int projectId, string name = null, bool needToFind = false)
        {
            ProjectPhaseApi projectPhaseApi = new ProjectPhaseApi();
            List<Phase> listProjectPhases = projectPhaseApi
                .GetProjectPhases(hubId, projectId);

            return __findSpecificObject(
                listProjectPhases,
                "Name",
                name,
                needToFind
            );
        }

        protected int __GetProjectPriorityRandom(int hubId, int projectId, string name = null, bool needToFind = false)
        {
            ProjectPriorityApi projectPriorityApi = new ProjectPriorityApi();
            List<Priority> listProjectPriorities = projectPriorityApi
                .GetProjectPriorities(hubId, projectId);

            return __findSpecificObject(
                listProjectPriorities,
                "Name",
                name,
                needToFind
            );
        }

        protected int __GetProjectStatusRandom(int hubId, int projectId, string name = null, bool needToFind = false)
        {
            ProjectStatusApi projectStatusApi = new ProjectStatusApi();
            List<Status> listProjectStatuses = projectStatusApi
                .GetProjectStatuses(hubId, projectId);
            
            return __findSpecificObject(
                listProjectStatuses,
                "Name",
                name,
                needToFind
            );
        }

        protected int __GetProjectTypeRandom(int hubId, int projectId, string name = null, bool needToFind = false)
        {
            ProjectTypeApi projectTypeApi = new ProjectTypeApi();
            List<BimType> listProjectTypes = projectTypeApi
                .GetProjectTypes(hubId, projectId);

            return __findSpecificObject(
                listProjectTypes,
                "Name",
                name,
                needToFind
            );
        }

        protected int __GetProjectZoneRandom(int hubId, int projectId, string name = null, bool needToFind = false)
        {
            ProjectZoneApi projectZoneApi = new ProjectZoneApi();
            List<Zone> listProjectZones = projectZoneApi
                .GetProjectZones(hubId, projectId);

            return __findSpecificObject(
                listProjectZones,
                "Name",
                name,
                needToFind
            );
        }
    }
}