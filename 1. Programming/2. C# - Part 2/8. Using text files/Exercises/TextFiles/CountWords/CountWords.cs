using System;
using System.IO;
using System.Text;

class CountWords
{
    static void Main()
    {
        try
        {
            StreamReader readFile;
            string[] words;
            string[] text;

            readFile = new StreamReader(@"..\..\..\TestFiles\Words.txt");

            using (readFile)
            {
                words = (readFile.ReadToEnd()).Split(' ');
            }

            readFile = new StreamReader(@"..\..\..\TestFiles\Test.txt");

            using (readFile)
            {
                text = (readFile.ReadToEnd()).Split(' ');
            }

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                int counter = 0;

                for (int j = 0; j < text.Length; j++)
                {
                    if (currentWord == text[j])
                    {
                        counter++;
                    }
                }

                if (counter < 10)
                {
                    words[i] = "00" + counter + " times found: " + words[i];
                }
                else if (counter < 100)
                {
                    words[i] = "0" + counter + " times found: " + words[i];
                }
                else if (counter < 1000)
                {
                    words[i] = counter + " times found: " + words[i];
                }
            }

            Array.Sort(words);
            Array.Reverse(words);

            StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\Result.txt");

            using (writeFile)
            {
                foreach (var word in words)
                {
                    writeFile.WriteLine(word);
                }
            }

            Console.WriteLine(@"Results were saved in TestFiles\Result.txt.");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Program runs out of memory.");
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("File cannot be open.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Enlarging the value of this instance would exceed the max capacity.");
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Buffer is full.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Contents of buffer cannot be written.");
        }
    }
}
