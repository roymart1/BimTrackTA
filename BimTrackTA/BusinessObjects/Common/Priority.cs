
namespace SeleniumTest.BusinessObjects
{
    public class Priority
    {
        public int Id { get; set; }
        // Order value of the priority
        public int Order { get; set; }
        // Color in hex format
        public string Color { get; set; }
        public string Name { get; set; }
    }
}