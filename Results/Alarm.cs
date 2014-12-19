using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents an Alarm in the stream.
    /// </summary>
    public class Alarm : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Alarm"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="device">Device.</param>
        public Alarm(XElement element, Device device)
            : base(element, device)
        {
            Code = element.Attribute("code").Value;
            NativeCode = element.Attribute("nativeCode").Value;
            Severity = element.Attribute("severity").Value;
            State = element.Attribute("state").Value;
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the native code.
        /// </summary>
        /// <value>The native code.</value>
        public string NativeCode { get; private set; }

        /// <summary>
        /// Gets the severity.
        /// </summary>
        /// <value>The severity.</value>
        public string Severity { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; private set; }
    }
}
