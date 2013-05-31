using System;
using System.Collections.Generic;

namespace GSMCharacteristics
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            //!!!Comment this to check the GSMTest and uncomment GSMTest.cs to test it

            Battery liONBattery = new Battery("LiON", 56, 9);
            Display bigDisplay = new Display(4, 65000);
            GSM phone = new GSM("N97Mini", "Nokia", 199.00M, "Ifaka", liONBattery, bigDisplay);

            Call currentCall = new Call(DateTime.Now.AddDays(6), "0888888888", 156);
            phone.AddCall(currentCall);

            currentCall = new Call(DateTime.Now, "0777777777", 456);
            phone.AddCall(currentCall);

            currentCall = new Call(DateTime.Now.AddHours(100), "0989565690", 345);
            phone.AddCall(currentCall);

            foreach (var item in phone.callHistory)
            {
                Console.WriteLine("Call time: {0}, Phone: {1}, Duration: {2}",
                    item.TimeOfCall, item.DialedPhoneNumber, item.CallDuration);
            }

            Console.WriteLine("Total price: $"+ phone.CalculateTotalPrice());

            long? maxCallDuration = long.MinValue;
            Call longestCall = new Call(DateTime.Now, "00000000", 0);

            foreach (var currentCallToCheck in phone.callHistory)
            {
                if (currentCallToCheck.CallDuration > maxCallDuration)
                {
                    maxCallDuration = currentCallToCheck.CallDuration;
                    longestCall = currentCallToCheck;
                }
            }

            phone.DeleteCall(longestCall);

            Console.WriteLine("Total price without longest call: $" + phone.CalculateTotalPrice());

            phone.ClearCalls();

            if (phone.callHistory.Count == 0)
            {
                Console.WriteLine("Calls clear!");
            }
        }
    }
}
