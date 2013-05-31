using System;

namespace GSMCharacteristics
{
    class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType type;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours idle cannot be less than 0.");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk cannot be less than 0.");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Battery(string model)
            : this(model, null)
        {
        }

        public Battery(string model, int? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
    }
}
