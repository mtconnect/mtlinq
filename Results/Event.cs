using System.Xml.Linq;

namespace MTSharp
{
    public class Event : Result
    {
        public Event(XElement element, Device device)
            : base(element, device)
        {
            Value = element.Value;
        }

        public string Value { get; protected set; }
    }
}
