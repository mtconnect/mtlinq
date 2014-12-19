using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Event in the stream.
    /// </summary>
    public class Event : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Event"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="device">Device.</param>
        public Event(XElement element, Device device)
            : base(element, device)
        {
            Value = element.Value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; protected set; }
    }
}
