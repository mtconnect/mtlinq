using System;
using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a Result in the stream.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.Result"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="device">Device.</param>
        public Result(XElement element, Device device)
        {
            string id = element.Attribute("dataItemId").Value;
            DataItem = device.GetDataItem(id);
            Sequence = UInt64.Parse(element.Attribute("sequence").Value);
            Timestamp = DateTime.Parse(element.Attribute("timestamp").Value);
        }

        /// <summary>
        /// Gets the data item.
        /// </summary>
        /// <value>The data item.</value>
        public DataItem DataItem { get; private set; }

        /// <summary>
        /// Gets the sequence.
        /// </summary>
        /// <value>The sequence.</value>
        public UInt64 Sequence { get; private set; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public DateTime Timestamp { get; private set; }
    }
}
