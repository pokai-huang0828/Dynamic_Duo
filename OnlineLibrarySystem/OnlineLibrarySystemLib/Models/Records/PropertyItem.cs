using System;

namespace OnlineLibrarySystemLib
{
    public class PropertyItem
    {
        public PropertyItem(String key, object value)
        {
            Key = key;
            Value = value;
        }

        public String Key { get; set; }
        public object Value { get; set; }
    }

}

