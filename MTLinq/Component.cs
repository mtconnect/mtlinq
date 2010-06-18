using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace MTLinq
{
    public class Component
    {
        private String mName;
        public String name { get { return mName; } }
        private String mId;
        public String id { get { return mId; } }
        private String mDescription;
        public String description { get { return mDescription; } }
        private String mManufacturer;
        public String manufacturer { get { return mManufacturer; } }
        private String mSerialNumber;
        public String serialNumber { get { return mSerialNumber; } }

        private List<Component> mComponents;
        private List<DataItem> mDataItems;
        private Component mParent;
        public Component parent { get { return mParent; } }

        public Component(Component aParent, XElement aElement, Dictionary<String, Component> aComps, 
                         Dictionary<String, DataItem> aItems)
        {
            mComponents = new List<Component>();
            mDataItems = new List<DataItem>();
            mParent = aParent;
            XNamespace mt = aElement.Name.Namespace;
            XElement desc = aElement.Element(mt + "Description");
            if (desc != null)
            {
                XAttribute att = desc.Attribute("manufacturer");
                if (att != null)
                    mManufacturer = att.Value;
                att = desc.Attribute("serialNumber");
                if (att != null)
                    mSerialNumber = att.Value;
                mDescription = desc.Value;
            }
            mName = aElement.Attribute("name").Value;
            mId = aElement.Attribute("id").Value;
            XElement ele = aElement.Element(mt + "Components");
            if (ele != null)
            {
                IEnumerable<XElement> children = ele.Elements();
                foreach (XElement child in children)
                {
                    Component c = new Component(this, child, aComps, aItems);
                    aComps.Add(c.id, c);
                    mComponents.Add(c);
                }
            }
            ele = aElement.Element(mt + "DataItems");
            if (ele != null)
            {
                IEnumerable<XElement> children = ele.Elements();
                foreach (XElement child in children)
                {
                    DataItem d = new DataItem(this, child);
                    aItems.Add(d.id, d);
                    mDataItems.Add(d);
                }
            }
        }

        public List<Component> components() { return mComponents; }
        public List<DataItem> dataItems() { return mDataItems; }
    }
}
