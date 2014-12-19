using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace MTSharp
{
    /// <summary>
    /// Represents a MTConnect stream
    /// </summary>
    public class MTConnect
    {
        string uri;
        Dictionary<string, Device> devices;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTSharp.MTConnect"/> class.
        /// </summary>
        /// <param name="uri">URI.</param>
        public MTConnect(string uri)
        {
            this.uri = uri;
        }

        /// <summary>
        /// Probe this instance for devices.
        /// </summary>
        public Dictionary<string, Device> Probe()
        {
            XElement root = XElement.Load(uri);
            XNamespace mt = root.Name.Namespace;

            this.devices = root.Descendants(mt + "Device").ToDictionary(
                el => el.Attribute("name").Value,
                el => new Device(uri, el, new Dictionary<string, Component>(), new Dictionary<string, DataItem>())
            );

            return this.devices;
        }

        /// <summary>
        /// Get all devices.
        /// </summary>
        public Dictionary<string, Device> Devices()
        {
            if (devices == null) Probe();
            return devices;
        }

        /// <summary>
        /// Get the current data from the stream.
        /// </summary>
        public Dictionary<string, IEnumerable<Result>> Current()
        {
            if (this.devices == null) Probe();

            if (this.devices == null) return null;

            Dictionary<string, IEnumerable<Result>> result = new Dictionary<string, IEnumerable<Result>>();

            string path = Url.Combine(uri, "current");

            Stopwatch sw = Stopwatch.StartNew();
            XElement root = XElement.Load(path);
            sw.Stop();
            Debug.WriteLine(string.Format("HTTP: {0}", sw.Elapsed.TotalMilliseconds));

            sw = Stopwatch.StartNew();

            XNamespace mt = root.Name.Namespace;

            var re = root.Descendants(mt + "DeviceStream")
                .Where(ds => this.devices.ContainsKey(ds.Attribute("name").Value))
                .ToDictionary(
                    devStream => devStream.Attribute("name").Value,
                    devStream => devStream.Elements(mt + "ComponentStream")
                        .Elements()
                        .SelectMany(e => ResultSelector(e, this.devices[devStream.Attribute("name").Value]))
                );

            sw.Stop();
            Debug.WriteLine(string.Format("Parsing: {0}", sw.Elapsed.TotalMilliseconds));
            return re;
        }

        private static Event EventSelector(XElement x, Device d)
        {
            if (x.Name == "Alarm")
                return new Alarm(x, d);
            else
                return new Event(x, d);
        }

        private static IEnumerable<Result> ResultSelector(XElement x, Device d)
        {
            switch (x.Name.LocalName)
            {
                case "Events":
                    return x.Elements().Select(e => EventSelector(e, d));
                case "Samples":
                    return x.Elements().Select(s => new Sample(s, d));
                case "Condition":
                    return x.Elements().Select(c => new Condition(c, d));
                default:
                    return Enumerable.Empty<Result>();
            }
        }
    }
}