using System;
using System.IO;

class ReadAllText
{


    static void Main()
    {
        Console.Write("Enter file with full path: ");
        string path = Console.ReadLine();
        string readText = string.Empty;


        try
        {
            readText = File.ReadAllText(path);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Your path is null.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Your path contains invalid characters or is blank.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Path is longer than system predefined.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File is not found.");
        }
        catch (IOException)
        {
            Console.WriteLine("I/O error.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to this file.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("File is not supported.");
        }

        Console.WriteLine(readText);
    }
}