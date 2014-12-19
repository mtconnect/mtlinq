using System.Collections.Generic;
using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Device in a stream.
    /// </summary>
    public class Device : Component
    {
        Dictionary<string, Component> allComponents;
        Dictionary<string, DataItem> allDataItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Device"/> class.
        /// </summary>
        /// <param name="uri">URI.</param>
        /// <param name="element">Element.</param>
        /// <param name="components">Components.</param>
        /// <param name="dataItems">Data items.</param>
        public Device(string uri, XElement element,
                      Dictionary<string, Component> components,
                      Dictionary<string, DataItem> dataItems)
            : base(null, element, components, dataItems)
        {
            Uri = uri;
            allComponents = components;
            allDataItems = dataItems;
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public string Uri { get; private set; }

        /// <summary>
        /// Gets a data item.
        /// </summary>
        /// <returns>The data item.</returns>
        /// <param name="id">Identifier.</param>
        public DataItem GetDataItem(string id) { return allDataItems[id]; }

        /// <summary>
        /// Get a component.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="id">Identifier.</param>
        public Component GetComponent(string id) { return allComponents[id]; }
    }
}
