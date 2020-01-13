namespace SeleniumTest.BusinessObjects
{
    public class Instance
    {
        public int Id { set; get; }
        public Xyz Position { set; get; }
        public Xyz Rotation { set; get; }
        public Xyz CropBoxSize { set; get; }
        public Xyz CropBoxCenter { set; get; }
        public Xyz CropBoxRotation { set; get; }
        public float Scale { set; get; }
        public bool IsClippingPlaneInverted { set; get; }
        public string ViewUniqueId { set; get; }
        public string ViewName { set; get; }
        public bool IsDefault { set; get; }
    }
}