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
        
        public List<Attachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ViewPoint> ViewPoints { get; set; }
        public IssueHistory ChangeSets { get; set; }
        
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

        public class ViewPoint
        {
            // TODO: Maybe add everything else (Pinpoint, Orthogonal Camera, Perspective Camera, ViewState, ViewStateSummary)
            public int Id { get; set; }
            public int IssueId { get; set; }
            public string ViewType { get; set; }
            public Image ViewPointImage { get; set; }
            public Comment Comments { get; set; }
            public string Source { get; set; }
            public string ViewName { get; set; }
            public string ModelName { get; set; }
            public string ViewUniqueId { get; set; }
            public bool WasCreatedFromSheetInstance { get; set; }
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
    }
}