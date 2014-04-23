using System;

namespace GSMCharacteristics
{
    class Call
    {
        private DateTime timeOfCall;
        private string dialedPhoneNumber;
        private long? callDuration;

        public DateTime TimeOfCall
        {
            get { return this.timeOfCall; }
            set { this.timeOfCall = value; }
        }

        public string DialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
            set { this.dialedPhoneNumber = value; }
        }

        public long? CallDuration
        {
            get { return this.callDuration; }
            set { this.callDuration = value; }
        }

        public Call(DateTime timeOfCall, string dialedPhoneNumber, long? callDuration)
        {
            this.TimeOfCall = timeOfCall;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.CallDuration = callDuration;
        }
    }
}
