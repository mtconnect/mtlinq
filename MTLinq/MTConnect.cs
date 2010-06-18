using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;

namespace MTLinq
{
    public class MTConnect
    {
        String mUri;
        Dictionary<String, Device> mDevices;

        public MTConnect(String aUri)
        {
            mUri = aUri;
        }

        public Dictionary<String,Device> probe()
        {
            mDevices = new Dictionary<string, Device>();
            XElement root = XElement.Load(mUri);
            XNamespace mt = root.Name.Namespace;
            IEnumerable<XElement> devices =
                from el in root.Descendants(mt + "Device")
                select el;
            foreach (XElement el in devices)
            {
                Device device = new Device(el, new Dictionary<String, Component>(),
                                    new Dictionary<String, DataItem>());
                mDevices.Add(device.name, device);
            }

            return mDevices;
        }

        public Dictionary<String, Device> devices()
        {
            if (mDevices == null) probe();
            return mDevices;
        }

        public List<Result> current()
        {
            if (mDevices == null) probe();

            List<Result> results = new List<Result>();
            String path = mUri + "current";
            XElement root = XElement.Load(path);
            XNamespace mt = root.Name.Namespace;
            IEnumerable<XElement> devices =
                from dev in root.Descendants(mt + "DeviceStream")
                select dev;
            foreach (XElement devStream in devices)
            {
                Device dev = mDevices[devStream.Attribute("name").Value];
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
