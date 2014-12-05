using System.Collections.Generic;
using System.Xml.Linq;

namespace MTConnect
{
    public class Device : Component
    {
        Dictionary<string, Component> allComponents;
        Dictionary<string, DataItem> allDataItems;

        public Device(XElement element,
                      Dictionary<string, Component> components,
                      Dictionary<string, DataItem> dataItems)
            : base(null, element, components, dataItems)
        {
            allComponents = components;
            allDataItems = dataItems;
        }

        public DataItem GetDataItem(string id) { return allDataItems[id]; }

        public Component GetComponent(string id) { return allComponents[id]; }
    }
}
