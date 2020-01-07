using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Project
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Image Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
        public List<Team> Teams { get; set; }
        public List<ProjectUser> Users { get; set; }
        
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public DateTime Date { get; set; }
            public string Url { get; set; }
            public DateTime UrlExpiration { get; set; }
            
            public List<Folder> Folders { get; set; }
            public List<Revision> Revisions { get; set; }
        }
        
        public class Sheet
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string UniqueId { get; set; }
            
            public List<Folder> Folders { get; set; }
            public List<Revision> Revisions { get; set; }
        }
        
        public class Team
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        
        public class ProjectUser
        {
            public User User { get; set; }
            public string Role { get; set; }
            public List<Team> Teams { get; set; }
//        public int DefaultFilterTemplateId { get; set; }      
            // DefaultFilterTemplateId: was removed from the DTO since it raises a casting exception 
        }
    }
}