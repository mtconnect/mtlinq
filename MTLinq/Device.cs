using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace MTLinq
{
    public class Device : Component
    {
        Dictionary<String, Component> mAllComponents;
        Dictionary<String, DataItem> mAllDataItems;

        public Device(XElement aElement, 
                      Dictionary<String, Component> aComponents,
                      Dictionary<String, DataItem> aDataItems)
            : base(null, aElement, aComponents, aDataItems)
        {
            mAllComponents = aComponents;
            mAllDataItems = aDataItems;
        }

        public DataItem getDataItem(String aId) { return mAllDataItems[aId]; }
        public Component getComponent(String aId) { return mAllComponents[aId]; }
    }
}
