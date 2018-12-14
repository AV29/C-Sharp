using dotNet_3.Attributes;

namespace dotNet_3
{
    [TrackingEntity]
    public class Tracked
    {
        private int _untrackedField;

        [TrackingProperty("Some custom Tracked Field")]
        private string _trackedField;

        [TrackingProperty("Some custom Tracked Property")]
        public string TrackedProp { get; }

        [TrackingProperty]
        public string TrackedPropWithOutName { get; set; }

        public Tracked(string trackedProp, string trackedField)
        {
            TrackedProp = trackedProp;
            _trackedField = trackedField;
        }
    }
}
