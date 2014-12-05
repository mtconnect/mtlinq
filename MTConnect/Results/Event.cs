using System.Xml.Linq;

namespace MTConnect
{
    public class Event : Result
    {
        public string Value { get; protected set; }

        public Event(XElement element, Device device)
            : base(element, device)
        {
            Value = element.Value;
        }
    }
}
