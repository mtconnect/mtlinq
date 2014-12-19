using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Data item in the stream.
    /// </summary>
    public class DataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.DataItem"/> class.
        /// </summary>
        /// <param name="comp">Comp.</param>
        /// <param name="element">Element.</param>
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

            XNamespace mt = element.Name.Namespace;
            XElement e = element.Element(mt + "Source");
            if (e != null) Source = e.Value;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the sub type.
        /// </summary>
        /// <value>The sub type.</value>
        public string SubType { get; private set; }

        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <value>The units.</value>
        public string Units { get; private set; }

        /// <summary>
        /// Gets the native units.
        /// </summary>
        /// <value>The native units.</value>
        public string NativeUnits { get; private set; }

        /// <summary>
        /// Gets the native scale.
        /// </summary>
        /// <value>The native scale.</value>
        public string NativeScale { get; private set; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; private set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; private set; }

        /// <summary>
        /// Gets the coordinate system.
        /// </summary>
        /// <value>The coordinate system.</value>
        public string CoordinateSystem { get; private set; }

        /// <summary>
        /// Gets the component.
        /// </summary>
        /// <value>The component.</value>
        public Component Component { get; private set; }
    }
}
