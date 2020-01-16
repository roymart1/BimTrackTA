
namespace SeleniumTest.BusinessObjects
{

    // N.B. : The BimType should really be named Type, but it conflicts with the reserved name Type.
    public class BimType
    {
        public int? Id { get; set; }
        // Color in hex format
        public string Color { get; set; }
        public string Name { get; set; }
    }
}