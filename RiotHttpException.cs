using System;
using System.Runtime.Serialization;

namespace RiotApi
{
    [Serializable]
    public class RiotHttpException : RiotApiException
    {
        public int StatusCode { get; set; }

        public RiotHttpException(int statusCode)
            : base("HTTP status code " + statusCode)
        {
            StatusCode = statusCode;
        }

        protected RiotHttpException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            StatusCode = info.GetInt32("StatusCode");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("StatusCode", StatusCode);
        }
    }
}