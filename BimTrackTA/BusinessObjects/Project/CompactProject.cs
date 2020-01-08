using System;

namespace SeleniumTest.BusinessObjects
{
    public class CompactProject
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Image Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
    }
}