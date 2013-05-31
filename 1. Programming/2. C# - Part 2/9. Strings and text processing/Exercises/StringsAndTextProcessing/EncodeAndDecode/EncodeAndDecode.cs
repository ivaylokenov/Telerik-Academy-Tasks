using System;
using System.Text;

class EncodeAndDecode
{
    static void Main()
    {
        Console.WriteLine("This program encodes and decodes a string.");
        Console.Write("Enter key: ");
        string key = Console.ReadLine();
        Console.Write("Enter message: ");
        string text = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Enter option: ");
        Console.WriteLine("1 - Encode");
        Console.WriteLine("2 - Decode");
        Console.WriteLine("3 - Exit");

        string option = Console.ReadLine();

        StringBuilder encrypt = new StringBuilder();
        StringBuilder decrypt = new StringBuilder();

        Console.WriteLine();

        switch (option)
        {
            case "1":
            case "2":
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        encrypt.Append((char)(text[i] ^ key[i % key.Length]));
                    }

                    Console.WriteLine("Encrypted message: {0}", encrypt.ToString());

                    string decryptedText = encrypt.ToString();

                    for (int i = 0; i < decryptedText.Length; i++)
                    {
                        decrypt.Append((char)(decryptedText[i] ^ key[i % key.Length]));
                    }

                    Console.WriteLine("Decrypted message: {0}", decrypt.ToString());

                    break;
                }

            case "3":
                {
                    return;
                }

            default:
                {
                    Console.WriteLine("Option invalid!");
                    return;
                }  
        }
    }
}
