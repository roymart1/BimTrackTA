using System;

namespace SeleniumTest.BusinessObjects
{
    public class Comment
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string CommentValue { get; set; }
        public string UniqueId { get; set; }
    }
}