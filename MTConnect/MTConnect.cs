using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MTConnect
{
    public class MTConnect
    {
        string uri;
        Dictionary<string, Device> devices;

        public MTConnect(string uri)
        {
            this.uri = uri;
        }

        public Dictionary<string, Device> Probe()
        {
            this.devices = new Dictionary<string, Device>();

            XElement root = XElement.Load(uri);
            XNamespace mt = root.Name.Namespace;

            IEnumerable<XElement> devices =
                from el in root.Descendants(mt + "Device")
                select el;

            foreach (XElement el in devices)
            {
                Device device = new Device(el, new Dictionary<string, Component>(),
                                    new Dictionary<string, DataItem>());
                this.devices.Add(device.Name, device);
            }

            return this.devices;
        }

        public Dictionary<string, Device> Devices()
        {
            if (devices == null) Probe();
            return devices;
        }

        public List<Result> Current()
        {
            if (this.devices == null) Probe();

            if (this.devices == null) return null;

            List<Result> results = new List<Result>();

            string path = Url.Combine(uri, "current");
            XElement root = XElement.Load(path);

            XNamespace mt = root.Name.Namespace;

            IEnumerable<XElement> devices =
                from dev in root.Descendants(mt + "DeviceStream")
                select dev;

            foreach (XElement devStream in devices)
            {
                Device dev = this.devices[devStream.Attribute("name").Value];

                if (dev != null)
                {
                    IEnumerable<XElement> streams =
                        from comp in devStream.Descendants(mt + "ComponentStream")
                        select comp;

                    foreach (XElement cs in streams)
                    {
                        IEnumerable<XElement> events =
                            from res in cs.Descendants(mt + "Events")
                            select res;

                        foreach (XElement ev in events)
                        {
                            IEnumerable<XElement> children = ev.Elements();
                            foreach (XElement re in children)
                            {
                                if (re.Name == "Alarm")
                                    results.Add(new Alarm(re, dev));
                                else
                                    results.Add(new Event(re, dev));
                            }
                        }

                        IEnumerable<XElement> samples =
                            from res in cs.Descendants(mt + "Samples")
                            select res;

                        foreach (XElement ev in samples)
                        {
                            IEnumerable<XElement> children = ev.Elements();
                            foreach (XElement re in children)
                                results.Add(new Sample(re, dev));
                        }

                        IEnumerable<XElement> conditions =
                            from res in cs.Descendants(mt + "Condition")
                            select res;

                        foreach (XElement cond in conditions)
                        {
                            IEnumerable<XElement> children = cond.Elements();
                            foreach (XElement re in children)
                                results.Add(new Condition(re, dev));
                        }
                    }
                }
            }
            return results;
        }
    }
}
