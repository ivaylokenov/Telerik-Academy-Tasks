using System;
using System.IO;
using System.Text;
using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestStartProgram
    {
        [TestMethod]
        public void TestCalendarSystemTestZero()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"AddEvent 2000-01-01T01:00:00 | party Viki | home
End");
            string expected = @"Event added
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestCalendarSystemTestFirst()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"AddEvent 2012-01-21T20:00:00 | party Viki | home
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T08:00:00 | C# exam
AddEvent 2012-03-07T22:30:00 | party | Vitosha
ListEvents 2012-03-07T08:00:00 | 3
DeleteEvents c# exam
DeleteEvents My granny's bushes
ListEvents 2013-11-27T08:30:25 | 25
AddEvent 2012-03-07T22:30:00 | party | Club XXX
ListEvents 2012-01-07T20:00:00 | 10
AddEvent 2012-03-07T22:30:00 | Party | Club XXX
ListEvents 2012-03-07T22:30:00 | 3
End");
            string expected = @"Event added
Event added
Event added
Event added
Event added
2012-03-07T22:30:00 | party | Vitosha
2012-03-26T08:00:00 | C# exam
2012-03-26T09:00:00 | C# exam
3 events deleted
No events found
No events found
Event added
2012-01-21T20:00:00 | party Viki | home
2012-03-07T22:30:00 | party | Club XXX
2012-03-07T22:30:00 | party | Vitosha
Event added
2012-03-07T22:30:00 | party | Club XXX
2012-03-07T22:30:00 | party | Vitosha
2012-03-07T22:30:00 | Party | Club XXX
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestCalendarSystemTestSecond()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"AddEvent 2000-01-01T01:00:00 | party Viki | home
ListEvents 2000-01-01T01:00:00 | 1
End
");
            string expected = @"Event added
2000-01-01T01:00:00 | party Viki | home
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestCalendarSystemTestThird()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"AddEvent 2000-01-01T01:00:00 | party Viki | home
AddEvent 2000-01-01T02:00:00 | party Viki (again) | home
ListEvents 2000-01-01T01:00:01 | 2
End
");
            string expected = @"Event added
Event added
2000-01-01T02:00:00 | party Viki (again) | home
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestCalendarSystemTestForth()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"AddEvent 2011-11-11T11:11:22 | party Viki | home
AddEvent 2011-11-11T11:11:22 | party Viki
AddEvent 2011-11-11T11:11:55 | party Viki | home
AddEvent 2011-11-11T11:11:33 | party Viki
AddEvent 2011-11-11T11:11:11 | party Viki | home
AddEvent 2011-11-11T11:11:44 | party Viki
AddEvent 2011-11-11T11:11:55 | party Viki
AddEvent 2011-11-11T11:11:33 | party Viki | home
AddEvent 2011-11-11T11:11:11 | party Viki
AddEvent 2011-11-11T11:11:44 | party Viki | home
ListEvents 2011-11-11T11:11:22 | 5
End");
            string expected = @"Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
2011-11-11T11:11:22 | party Viki
2011-11-11T11:11:22 | party Viki | home
2011-11-11T11:11:33 | party Viki
2011-11-11T11:11:33 | party Viki | home
2011-11-11T11:11:44 | party Viki
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void TestCalendarSystemTestFifth()
        {
            var output = new StringWriter();
            var input = new StringReader(
                @"DeleteEvents party @ Mimi
DeleteEvents party Viki 22
AddEvent 2011-11-11T11:11:22 | party Viki 22 | home
AddEvent 2011-11-11T11:11:22 | party Viki (11:22)
AddEvent 2011-11-11T11:11:55 | party Viki 55 | home
AddEvent 2011-11-11T11:11:33 | party Viki (11:33)
AddEvent 2011-11-11T11:11:11 | party Viki 11 | home
AddEvent 2011-11-11T11:11:44 | party Viki (11:44)
AddEvent 2011-11-11T11:11:55 | party Viki (11:55)
AddEvent 2011-11-11T11:11:33 | party Viki 33 | home
AddEvent 2011-11-11T11:11:11 | party Viki (11:11)
AddEvent 2011-11-11T11:11:44 | party Viki | home
ListEvents 2011-11-11T11:11:22 | 3
DeleteEvents party @ Kiro
ListEvents 2011-11-11T11:11:11 | 2
End");
            string expected = @"No events found
No events found
Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
Event added
2011-11-11T11:11:22 | party Viki (11:22)
2011-11-11T11:11:22 | party Viki 22 | home
2011-11-11T11:11:33 | party Viki (11:33)
No events found
2011-11-11T11:11:11 | party Viki (11:11)
2011-11-11T11:11:11 | party Viki 11 | home
";

            using (output)
            {
                using (input)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);

                    StartProgram.Main();

                    string actual = output.ToString();
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        /// <summary>
        /// Tests all external tests. Just change file.
        /// </summary>
        [TestMethod]
        public void TestExternalTests()
        {
            StreamReader reader = new StreamReader("../../../Tests/test.006.in.txt");
            var output = new StringWriter();

            string expected;

            using (reader)
            {
                Console.SetIn(reader);
                Console.SetOut(output);
                StartProgram.Main();
            }

            StringBuilder expectedSB = new StringBuilder();
            reader = new StreamReader("../../../Tests/test.006.out.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while(line != null)
                {
                    expectedSB.AppendLine(line);
                    line = reader.ReadLine();
                }
            }

            expected = expectedSB.ToString();

            Assert.AreEqual(expected, output.ToString());
        }
    }
}