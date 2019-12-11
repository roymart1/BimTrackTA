using System;

namespace SeleniumTest.BusinessObjects
{
    public class Hub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorCls Author { get; set; }
        public ImageCls Image { get; set; }
        public string CreationDate { get; set; }

        public class AuthorCls
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AvatarUrl { get; set; }

        }
        
        public class ImageCls
        {
            public string ThumbnailUrl { get; set; }
            public DateTime ThumbnailUrlExpiration { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public DateTime Date { get; set; }
            public string Url { get; set; }
            public DateTime UrlExpiration { get; set; }
        }
    }
}