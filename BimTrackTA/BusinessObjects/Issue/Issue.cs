using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Issue
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public Author IssueAuthor { get; set; }
        public User AssignedTo { get; set; }
        public Author LastModificationAuthor { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int DefaultViewpointId { get; set; }
        public List<Discipline> Disciplines { get; set; }
        
        public ProjectCustomAttributeValue ProjectPhase { get; set; }
        public ProjectCustomAttributeValue ProjectZone { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public ProjectCustomAttributeValue Type { get; set; }
        public IssueConfidentiality Confidentiality { get; set; }
        public IssueNotifyList NotifyList { get; set; }

        public List<Attachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ViewPoint> ViewPoints { get; set; }
        public IssueHistory ChangeSets { get; set; }
        public List<ProjectCustomAttribute> CustomAttributes { get; set; }
        public string CreationSource { get; set; }
        
        public class Attachment
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public DateTime Date { get; set; }
            public string Url { get; set; }
            public DateTime UrlExpiration { get; set; }
        }

        public class Comment
        {
            public int Id { get; set; }
            public User Author { get; set; }
            public DateTime CreationDate { get; set; }
            public string CommentValue { get; set; }
            public string UniqueId { get; set; }
        }

        public class IssueHistory
        {
            public List<ChangeSet> ChangeSets { get; set; }

            public class ChangeSet
            {
                public User Author { get; set; }
                public DateTime CreationDate { get; set; }
                public string ChangeType { get; set; }
                private List<Change> Changes { get; set; }

                public class Change
                {
                    public string NewValye { get; set; }
                    public string OldValue { get; set; }
                    public string Property { get; set; }
                }
            }
        }

        public class IssuePriority
        {
            public int Order { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
        }

        public class IssueStatus
        {
            public List<Team> TeamsAllowedForStatus { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
            public int Id { get; set; } 
        }

        public class IssueConfidentiality
        {
            public List<Team> Teams { get; set; }
        }

        public class IssueNotifyList
        {
            public List<Team> TeamsToNotify { get; set; }
            public List<User> UsersToNotify { get; set; }
        }
    }
}