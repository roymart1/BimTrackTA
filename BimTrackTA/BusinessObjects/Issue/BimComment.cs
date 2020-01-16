using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class BimComment
    {
        public int? Id { get; set; }
        public Author Author { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Comment { get; set; }
        public string UniqueId { get; set; }
    }
}