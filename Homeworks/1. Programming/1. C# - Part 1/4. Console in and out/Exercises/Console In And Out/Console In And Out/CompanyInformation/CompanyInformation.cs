using System;
using System.Threading;
using System.Globalization;

class CompanyInformation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Company";
        string title = new string('-', 26);
        Console.WriteLine(title);
        Console.WriteLine("ADMINISTRATIVE INFORMATION");
        Console.WriteLine(title + "\n\r");
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        string readStr = Console.ReadLine();
        uint companyPhone;
        bool parseSuccess = UInt32.TryParse(readStr, out companyPhone);
        while (parseSuccess == false)
        {
            Console.Write("Company phone number is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out companyPhone);
        }
        Console.Write("Enter company fax number: ");
        readStr = Console.ReadLine();
        uint companyFax;
        parseSuccess = UInt32.TryParse(readStr, out companyFax);
        while (parseSuccess == false)
        {
            Console.Write("Company fax number is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out companyFax);
        }
        Console.Write("Enter company web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter manager's first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter manager's last name: ");
        string managerSecondName = Console.ReadLine();
        Console.Write("Enter manager's age: ");
        readStr = Console.ReadLine();
        byte managerAge;
        parseSuccess = byte.TryParse(readStr, out managerAge);
        while (parseSuccess == false)
        {
            Console.Write("Manager's age is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = byte.TryParse(readStr, out managerAge);
        }
        Console.Write("Enter manager's phone number: ");
        readStr = Console.ReadLine();
        uint managerPhone;
        parseSuccess = UInt32.TryParse(readStr, out managerPhone);
        while (parseSuccess == false)
        {
            Console.Write("Manager phone number is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out managerPhone);
        }
        string companyInfoTitle = new string('-', 19);
        Console.WriteLine("\n\r" + companyInfoTitle);
        Console.WriteLine("COMPANY INFORMATION");
        Console.WriteLine(companyInfoTitle + "\n\r");
        Console.WriteLine("Company name: {0}\n\rCompany address: {1}\n\rCompany phone number: {2}\n\rCompanyFax: {3}\n\rCompany web site: {4}\n\r", companyName, companyAddress, companyPhone, companyFax, companyWebSite);
        string managerInfoTitle = new string('-', 19);
        Console.WriteLine(managerInfoTitle);
        Console.WriteLine("MANAGER INFORMATION");
        Console.WriteLine(managerInfoTitle +"\n\r");
        Console.WriteLine("Manager's first name: {0}\n\rManager's last name: {1}\n\rManager's age: {2}\n\rManager's phone: {3}\n\r", managerFirstName, managerSecondName, managerAge, managerPhone);
    }
}
