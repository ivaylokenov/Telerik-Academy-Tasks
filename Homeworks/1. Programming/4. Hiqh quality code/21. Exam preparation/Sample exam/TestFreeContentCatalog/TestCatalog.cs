using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestFreeContentCatalog
{
    [TestClass]
    public class TestCatalog
    {
        [TestMethod]
        public void TestSampleInputOutput()
        {
            var output = new StringWriter();
            var input = new StringReader(
                "Find: One; 3" + "\r\n" +
                "Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org\r\n" +
                "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info\r\n" +
                "Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs\r\n" +
                "Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d\r\n" +
                "Find: One; 1\r\n" +
                "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/\r\n" +
                "Find: One; 10\r\n" +
                "Update: http://www.introprogramming.info; http://introprograming.info/en/\r\n" +
                "Find: Intro C#; 1\r\n" +
                "Update: http://nakov.com; sftp://www.nakov.com\r\n" +
                "End\r\n"
                );
            string expected = "No items found\r\n" +
                "Application added\r\n" +
                "Book added\r\n" +
                "Song added\r\n" +
                "Movie added\r\n" +
                "Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs" + "\r\n" +
                "Movie added\r\n" +
                "Movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/" + "\r\n" +
                "Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs" + "\r\n" +
                "1 items updated\r\n" +
                "Book: Intro C#; S.Nakov; 12763892; http://introprograming.info/en/" + "\r\n" +
                "0 items updated\r\n";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    FreeContentCatalog.ContentCatalog.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
