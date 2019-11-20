namespace SeleniumTest.BusinessObjects
{
    public class Hub
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AuthorCls Author { get; set; }
        public string Image { get; set; }
        public string CreationDate { get; set; }

        public class AuthorCls
        {
            public long Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AvatarUrl { get; set; }

        }
    }
}