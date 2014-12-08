using System.Collections.Generic;
using System.Xml.Linq;

namespace MTSharp
{
    public class Component
    {
        List<Component> components;
        List<DataItem> dataItems;

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

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Description { get; private set; }

        public string Manufacturer { get; private set; }

        public string SerialNumber { get; private set; }

        public Component Parent { get; private set; }

        public List<Component> Components() { return components; }

        public List<DataItem> DataItems() { return dataItems; }
    }
}
