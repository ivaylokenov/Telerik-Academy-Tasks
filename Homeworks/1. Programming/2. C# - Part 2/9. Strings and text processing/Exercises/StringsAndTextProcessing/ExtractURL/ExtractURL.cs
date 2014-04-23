using System;
using System.Text;

class ExtractURL
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";
        StringBuilder extract = new StringBuilder();

        int index = url.IndexOf("://");

        for (int i = 0; i < index; i++)
        {
            extract.Append(url[i]);
        }

        string protocol = extract.ToString();

        url = url.Remove(0, index + 3);

        extract.Clear();

        index = url.IndexOf("/");

        for (int i = 0; i < index; i++)
        {
            extract.Append(url[i]);
        }

        string server = extract.ToString();

        extract.Clear();

        for (int i = index; i < url.Length; i++)
        {
            extract.Append(url[i]);
        }

        string resourse = extract.ToString();

        Console.WriteLine("Protocol: {0}", protocol);
        Console.WriteLine("Server: {0}", server);
        Console.WriteLine("Resourse: {0}", resourse);
    }
}
