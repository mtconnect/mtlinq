using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace MTLinq
{
    public class Result
    {
        DataItem mDataItem;
        public DataItem dataItem { get { return mDataItem; } }
        UInt64 mSequence;
        public UInt64 sequence { get { return mSequence; } }
        DateTime mTimestamp;
        public DateTime timestamp { get { return mTimestamp; } }

        public Result(XElement aElement, Device aDevice)
        {
            String id = aElement.Attribute("dataItemId").Value;
            mDataItem = aDevice.getDataItem(id);
            mSequence = UInt64.Parse(aElement.Attribute("sequence").Value);
            mTimestamp = DateTime.Parse(aElement.Attribute("timestamp").Value);
        }
    }

    public class Event : Result
    {
        protected String mValue;
        public String value { get { return mValue; } }

        public Event(XElement aElement, Device aDevice)
            : base(aElement, aDevice)
        {
            mValue = aElement.Value;
        }
    }

    public class Sample : Result
    {
        Double mValue;
        public Double value { get { return mValue; } }

        public Sample(XElement aElement, Device aDevice)
            : base(aElement, aDevice)
        {
            if (aElement.Value != "UNAVAILABLE")
                mValue = Double.Parse(aElement.Value);
            else
                mValue = 0.0;
        }
    }

    public class Alarm : Event
    {
        String mCode;
        public String code { get { return mCode; } }
        String mNativeCode;
        public String nativeCode { get { return mNativeCode; } }
        String mSeverity;
        public String severity { get { return mSeverity; } }
        String mState;
        public String state { get { return mState; } }

        public Alarm(XElement aElement, Device aDevice)
            : base(aElement, aDevice)
        {
            mCode = aElement.Attribute("code").Value;
            mNativeCode = aElement.Attribute("nativeCode").Value;
            mSeverity = aElement.Attribute("severity").Value;
            mState = aElement.Attribute("state").Value;
            
        }
    }

    public class Condition : Event
    {
        String mNativeCode;
        public String nativeCode { get { return mNativeCode; } }
        String mNativeSeverity;
        public String nativeSeverity { get { return mNativeSeverity; } }
        String mType;
        public String type { get { return mType; } }
        String mQualifier;
        public String qualifier { get { return mQualifier; } }


        public Condition(XElement aElement, Device aDevice)
            : base(aElement, aDevice)
        {
            if (aElement.Attribute("nativeCode") != null)
                mNativeCode = aElement.Attribute("nativeCode").Value;
            if (aElement.Attribute("nativeSeverity") != null)
                mNativeSeverity = aElement.Attribute("nativeSeverity").Value;
            if (aElement.Attribute("qualifier") != null)
                mQualifier = aElement.Attribute("qualifier").Value;
            mType = aElement.Attribute("type").Value;
            mValue = mType + ":" + aElement.Name.LocalName + ":" + mValue;
        }
    }
}
