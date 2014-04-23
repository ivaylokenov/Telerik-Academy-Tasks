using System;
using System.Linq;

class FloatToBinary
{
    //converts floating point number to hex 
    public static string GetBytesSingle(float argument)
    {
        byte[] byteArray = BitConverter.GetBytes(argument);
        Array.Reverse(byteArray);
        string result = BitConverter.ToString(byteArray);
        return result;
    }

    public static void Main()
    {
        //get number
        Console.Write("Enter 32-bit floating point number: ");
        float number = Single.Parse(Console.ReadLine());

        //convert it to hex
        string result = GetBytesSingle(number);
        string binaryFloat = "";

        //convert hex to binary
        for (int i = 0; i < result.Length; i++)
        {
            switch (result[i])
            {
                case '0':
                    binaryFloat += "0000";
                    break;
                case '1':
                    binaryFloat += "0001";
                    break;
                case '2':
                    binaryFloat += "0010";
                    break;
                case '3':
                    binaryFloat += "0011";
                    break;
                case '4':
                    binaryFloat += "0100";
                    break;
                case '5':
                    binaryFloat += "0101";
                    break;
                case '6':
                    binaryFloat += "0110";
                    break;
                case '7':
                    binaryFloat += "0111";
                    break;
                case '8':
                    binaryFloat += "1000";
                    break;
                case '9':
                    binaryFloat += "1001";
                    break;
                case 'A':
                    binaryFloat += "1010";
                    break;
                case 'a':
                    binaryFloat += "1010";
                    break;
                case 'B':
                    binaryFloat += "1011";
                    break;
                case 'b':
                    binaryFloat += "1011";
                    break;
                case 'C':
                    binaryFloat += "1100";
                    break;
                case 'c':
                    binaryFloat += "1100";
                    break;
                case 'D':
                    binaryFloat += "1101";
                    break;
                case 'd':
                    binaryFloat += "1101";
                    break;
                case 'E':
                    binaryFloat += "1110";
                    break;
                case 'e':
                    binaryFloat += "1110";
                    break;
                case 'F':
                    binaryFloat += "1111";
                    break;
                case 'f':
                    binaryFloat += "1111";
                    break;
            }
        }

        //print floating point number
        Console.Write("Result: ");
        for (int i = 0; i < binaryFloat.Length; i++)
        {
            Console.Write(binaryFloat[i]);
            if (i == 0 || i == 8)
            {

                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}

