using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Sheet
    {
        public CompactProject Project { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueId { get; set; }
        
        public Folder Folder { get; set; }
        public List<Revision> Revisions { get; set; }
    
    }
}