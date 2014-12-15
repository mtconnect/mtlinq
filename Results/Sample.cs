using System.Xml.Linq;

namespace MTSharp
{
    public class Sample : Result
    {
        public Sample(XElement element, Device device)
            : base(element, device)
        {
            if (element.Value != "UNAVAILABLE")
                Value = double.Parse(element.Value);
            else
                Value = 0.0;
        }

        public double Value { get; private set; }
    }
}
