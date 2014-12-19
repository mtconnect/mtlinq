using System.Collections.Generic;
using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Component in the stream.
    /// </summary>
    public class Component
    {
        List<Component> components;
        List<DataItem> dataItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Component"/> class.
        /// </summary>
        /// <param name="parent">Parent.</param>
        /// <param name="element">Element.</param>
        /// <param name="comps">Components.</param>
        /// <param name="items">Items.</param>
        public Component(Component parent, XElement element, Dictionary<string, Component> comps,
                         Dictionary<string, DataItem> items)
        {
            components = new List<Component>();
            dataItems = new List<DataItem>();

            Parent = parent;

            XNamespace mt = element.Name.Namespace;
            XElement desc = element.Element(mt + "Description");

            if (desc != null)
            {
                XAttribute att = desc.Attribute("manufacturer");

                if (att != null)
                    Manufacturer = att.Value;

                att = desc.Attribute("serialNumber");

                if (att != null)
                    SerialNumber = att.Value;

                Description = desc.Value;
            }

            Name = element.Attribute("name").Value;
            Id = element.Attribute("id").Value;

            XElement ele = element.Element(mt + "Components");

            // TODO: Make into Linq statement
            if (ele != null)
            {
                IEnumerable<XElement> children = ele.Elements();
                foreach (XElement child in children)
                {
                    Component c = new Component(this, child, comps, items);
                    comps.Add(c.Id, c);
                    components.Add(c);
                }
            }

            ele = element.Element(mt + "DataItems");

            if (ele != null)
            {
                IEnumerable<XElement> children = ele.Elements();
                foreach (XElement child in children)
                {
                    DataItem d = new DataItem(this, child);
                    items.Add(d.Id, d);
                    dataItems.Add(d);
                }
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; private set; }

        /// <summary>
        /// Gets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public Component Parent { get; private set; }

        /// <summary>
        /// Get the sub components.
        /// </summary>
        public List<Component> Components() { return components; }

        /// <summary>
        /// Get the data items.
        /// </summary>
        /// <returns>The data items.</returns>
        public List<DataItem> DataItems() { return dataItems; }
    }
}
