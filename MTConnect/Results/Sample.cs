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
    public class Sample : Result
    {
        public double Value { get; private set; }

        public Sample(XElement element, Device device)
            : base(element, device)
        {
            if (element.Value != "UNAVAILABLE")
                Value = double.Parse(element.Value);
            else
                Value = 0.0;
        }
    }
}
