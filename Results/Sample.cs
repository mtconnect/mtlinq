using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Sample in the stream.
    /// </summary>
    public class Sample : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Sample"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="device">Device.</param>
        public Sample(XElement element, Device device)
            : base(element, device)
        {
            if (element.Value != "UNAVAILABLE")
                Value = double.Parse(element.Value);
            else
                Value = 0.0;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; private set; }
    }
}
