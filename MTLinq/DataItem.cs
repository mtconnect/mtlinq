using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace MTLinq
{
    public class DataItem
    {
        private String mId;
        public String id { get { return mId; } }
        private String mName;
        public String name { get { return mName; } }
        private String mType;
        public String type { get { return mType; } }
        private String mSubType;
        public String subType { get { return mSubType; } }
        private String mUnits;
        public String units { get { return mUnits; } }
        private String mNativeUnits;
        public String nativeUnits { get { return mNativeUnits; } }
        private String mNativeScale;
        public String nativeScale { get { return mNativeScale; } }
        private String mCategory;
        public String category { get { return mCategory; } }
        private String mSource;
        public String source { get { return mSource; } }
        private String mCoordinateSystem;
        public String coordinateSystem { get { return mCoordinateSystem; } }

        Component mComponent;

        public DataItem(Component aComp, XElement aElement)
        {
            mComponent = aComp;

            XAttribute a = aElement.Attribute("id");
            if (a != null) mId = a.Value;
            a = aElement.Attribute("name");
            if (a != null) mName = a.Value;
            a = aElement.Attribute("type");
            if (a != null) mType = a.Value;
            a = aElement.Attribute("subType");
            if (a != null) mSubType = a.Value;
            a = aElement.Attribute("units");
            if (a != null) mUnits = a.Value;
            a = aElement.Attribute("nativeUnits");
            if (a != null) mNativeUnits = a.Value;
            a = aElement.Attribute("nativeScale");
            if (a != null) mNativeScale = a.Value;
            a = aElement.Attribute("category");
            if (a != null) mCategory = a.Value;
            a = aElement.Attribute("coordinateSystem");
            if (a != null) mCoordinateSystem = a.Value;
            XNamespace mt = "urn:mtconnect.com:MTConnectDevices:1.0";
            XElement e = aElement.Element(mt + "Source");
            if (e != null) mSource = e.Value;
        }

        public Component component { get { return mComponent; } }
    }
}
