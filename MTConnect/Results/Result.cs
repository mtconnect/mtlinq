using System;
using System.Xml.Linq;

namespace MTConnect
{
    public class Result
    {
        public DataItem DataItem { get; private set; }

        public UInt64 Sequence { get; private set; }

        public DateTime Timestamp { get; private set; }

        public Result(XElement element, Device device)
        {
            string id = element.Attribute("dataItemId").Value;
            DataItem = device.GetDataItem(id);
            Sequence = UInt64.Parse(element.Attribute("sequence").Value);
            Timestamp = DateTime.Parse(element.Attribute("timestamp").Value);
        }
    }
}
