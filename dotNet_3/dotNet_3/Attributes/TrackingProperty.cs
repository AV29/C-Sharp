using System;

namespace dotNet_3.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class TrackingPropertyAttribute: Attribute
    {
        public string PropertyName { get; }

        public TrackingPropertyAttribute()
        {
            PropertyName = "";
        }

        public TrackingPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
