using System;

namespace SeleniumTest.BusinessObjects
{
    public class BimFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public DateTime UrlExpiration { get; set; }
    }
}