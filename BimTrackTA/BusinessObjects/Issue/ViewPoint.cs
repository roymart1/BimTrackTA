using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class ViewPoint
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string ViewType { get; set; }
        public BimImage BimImage { get; set; }
        public List<BimComment> Comments { get; set; }
        public string Source { get; set; }
        public string ViewName { get; set; }
        public string ModelName { get; set; }
        public string ViewUniqueId { get; set; }
        public bool WasCreatedFromSheetInstance { get; set; }

        public ViewPointViewStateSummary ViewStateSummary { get; set; }
        public ViewPointViewState ViewState { get; set; }
        public Camera PerspectiveCamera { get; set; }
        public Camera OrthogonalCamera { get; set; }
        public ViewPointPinPoint PinPoint { get; set; }
        
        
        
        public class ViewPointViewStateSummary
        {
            public string ClipMode { get; set; }
            public List<Plane> ClippingPlanes { get; set; }
            public SectionBox SectionBox { get; set; }
            public bool HasHiddenElements { get; set; }
            public bool HasSelectedElements { get; set; }
        }

        public class ViewPointViewState
        {
            public List<Element> HiddenElements { get; set; }
            public List<HiddenModel> HiddenModels { get; set; }
            public List<Element> SelectedElements { get; set; }
            public string ClipMode { get; set; }
            public List<Plane> ClippingPlanes { get; set; }
            public List<SectionBox> ViewStateSectionBox { get; set; }

            public bool HasHiddenElements { get; set; }
            public bool HasSelectedElements { get; set; }


            public class HiddenModel
            {
                public string ModelName { get; set; }
                public string ModelGuid { get; set; }
            }
        }

        public class Camera
        {
            public Xyz CameraPosition { get; set; }
            public Xyz CameraDirection { get; set; }
            public Xyz CameraUpVector { get; set; }
            public int FieldOfView { get; set; }
            public int ViewToWorldScale { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
        }

        public class ViewPointPinPoint
        {
            public string Name { get; set; }
            public Xyz Position { get; set; }
            public Element Element1 { get; set; }
            public Element Element2 { get; set; }
        }
    }
}