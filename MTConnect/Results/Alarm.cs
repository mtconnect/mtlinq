//************************************************************************************
//
// Author: Jacob Ebey
//
// Copyright © 2013-2014 OMAX Corporation
//
//************************************************************************************

using System.Xml.Linq;

namespace MTConnect
{
    public class Alarm : Event
    {
        public string Code { get; private set; }

        public string NativeCode { get; private set; }

        public string Severity { get; private set; }

        public string State { get; private set; }

        public Alarm(XElement element, Device device)
            : base(element, device)
        {
            Code = element.Attribute("code").Value;
            NativeCode = element.Attribute("nativeCode").Value;
            Severity = element.Attribute("severity").Value;
            State = element.Attribute("state").Value;

        }
    }
}
