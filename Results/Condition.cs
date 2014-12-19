using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Condition.
    /// </summary>
    public class Condition : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Condition"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="device">Device.</param>
        public Condition(XElement element, Device device)
            : base(element, device)
        {
            if (element.Attribute("nativeCode") != null)
                NativeCode = element.Attribute("nativeCode").Value;
            if (element.Attribute("nativeSeverity") != null)
                NativeSeverity = element.Attribute("nativeSeverity").Value;
            if (element.Attribute("qualifier") != null)
                Qualifier = element.Attribute("qualifier").Value;
            Type = element.Attribute("type").Value;
            Value = Type + ":" + element.Name.LocalName + ":" + Value;
        }

        /// <summary>
        /// Gets the native code.
        /// </summary>
        /// <value>The native code.</value>
        public string NativeCode { get; private set; }

        /// <summary>
        /// Gets the native severity.
        /// </summary>
        /// <value>The native severity.</value>
        public string NativeSeverity { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the qualifier.
        /// </summary>
        /// <value>The qualifier.</value>
        public string Qualifier { get; private set; }
    }
}
