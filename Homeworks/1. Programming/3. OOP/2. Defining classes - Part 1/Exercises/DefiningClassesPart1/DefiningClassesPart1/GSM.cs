using System;
using System.Text;
using System.Collections.Generic;

namespace GSMCharacteristics
{
    class GSM
    {
        private Battery battery;
        private Display display;
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private static readonly GSM iPhone4S = new GSM("iPhone4S", "Apple", 1500.00M, "ME!!!");
        public List<Call> callHistory = new List<Call>();
        private static readonly decimal pricePerMinute = 0.37M;

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than 0.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price)
            : this(model, manufactorer, price, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner)
            : this(model, manufactorer, price, owner, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner, Battery battery)
            : this(model, manufactorer, price, owner, battery, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufactorer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (model != null)
            {
                output.AppendLine("------------------");
                output.AppendLine(Model + " characteristics");
                output.AppendLine();
            }

            if (Manufacturer != null)
            {
                output.AppendLine("Manufacturer: " + Manufacturer);
            }

            if (Price != null)
            {
                output.AppendLine("Price: $" + Price);
            }

            if (Owner != null)
            {
                output.AppendLine("Owner: " + Owner);
            }

            if (Display != null && Display.Size != null)
            {
                output.AppendLine("Display size: " + Display.Size + " inches");
            }

            if (Display != null && Display.Colors != null)
            {
                output.AppendLine("Display colors: " + Display.Colors + " colors");
            }

            if (Battery != null && Battery.Type != null)
            {
                output.AppendLine("Battery type: " + Battery.Type);
            }

            if (Battery != null && Battery.Model != null)
            {
                output.AppendLine("Battery model: " + Battery.Model);
            }

            if (Battery != null && Battery.HoursIdle != null)
            {
                output.AppendLine("Hours idle: " + Battery.HoursIdle + " hours");
            }

            if (Battery != null && Battery.HoursTalk != null)
            {
                output.AppendLine("Hours talk: " + Battery.HoursTalk + " hours");
            }

            return output.ToString();

            //return string.Format("{0} characteristics\n\rManufacturer: {1}\n\rPrice: {2}\n\rOwner: {3}\n\rDisplay size: {4}\n\rDisplay colors: {5}\n\rBattery type: {6}\n\rBattery model: {7}\n\rHours idle: {8}\n\rHours talk: {9}\n\r\n\r"
            //, Model, Manufacturer, Price, Owner, Display.Size, Display.Colors, Battery.Type, Battery.Model, Battery.HoursIdle, Battery.HoursTalk);
        }

        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            callHistory.Remove(call);
        }

        public void ClearCalls()
        {
            callHistory.Clear();
        }

        public decimal? CalculateTotalPrice()
        {
            decimal? duration = 0;

            foreach (var item in callHistory)
            {
                duration += item.CallDuration;
            }

            return duration = (duration/60) * pricePerMinute;
        }
    }
}