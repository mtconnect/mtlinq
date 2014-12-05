using System.Xml.Linq;

namespace MTConnect
{
    public class DataItem
    {
        public DataItem(Component comp, XElement element)
        {
            Component = comp;

            XAttribute a = element.Attribute("id");
            if (a != null) Id = a.Value;

            a = element.Attribute("name");
            if (a != null) Name = a.Value; else Name = Id;

            a = element.Attribute("type");
            if (a != null) Type = a.Value;

            a = element.Attribute("subType");
            if (a != null) SubType = a.Value;

            a = element.Attribute("units");
            if (a != null) Units = a.Value;

            a = element.Attribute("nativeUnits");
            if (a != null) NativeUnits = a.Value;

            a = element.Attribute("nativeScale");
            if (a != null) NativeScale = a.Value;

            a = element.Attribute("category");
            if (a != null) Category = a.Value;

            a = element.Attribute("coordinateSystem");
            if (a != null) CoordinateSystem = a.Value;

            // TODO: If it breaks, change back to a constant.
            //XNamespace mt = Constants.Namespace;
            XNamespace mt = element.Name.Namespace;
            XElement e = element.Element(mt + "Source");
            if (e != null) Source = e.Value;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public string SubType { get; private set; }

        public string Units { get; private set; }

        public string NativeUnits { get; private set; }

        public string NativeScale { get; private set; }

        public string Category { get; private set; }

        public string Source { get; private set; }

        public string CoordinateSystem { get; private set; }

        public Component Component { get; private set; }
    }
}
