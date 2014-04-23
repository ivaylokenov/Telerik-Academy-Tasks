using System;
using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void TestAddEventDateTitle()
        {
            string addEvent = "AddEvent 2011-11-11T11:11:22 | NikakvoParty!";
            Command command = Command.Parse(addEvent);
            Assert.AreEqual("AddEvent", command.CommandName);
            Assert.AreEqual("2011-11-11T11:11:22", command.Parameters[0]);
            Assert.AreEqual("NikakvoParty!", command.Parameters[1]);
        }

        [TestMethod]
        public void TestAddEventDateTitleLocation()
        {
            string addEvent = "AddEvent 2000-01-01T00:00:00 | NikakvoParty! | Nikade";
            Command command = Command.Parse(addEvent);
            Assert.AreEqual("AddEvent", command.CommandName);
            Assert.AreEqual("2000-01-01T00:00:00", command.Parameters[0]);
            Assert.AreEqual("NikakvoParty!", command.Parameters[1]);
            Assert.AreEqual("Nikade", command.Parameters[2]);
        }

        [TestMethod]
        public void TestDeleteEvent()
        {
            string deleteEvent = "DeleteEvents Bai Ivan";
            Command command = Command.Parse(deleteEvent);
            Assert.AreEqual("DeleteEvents", command.CommandName);
            Assert.AreEqual("Bai Ivan", command.Parameters[0]);
        }

        [TestMethod]
        public void TestListEvents()
        {
            string listEvent = "ListEvents 2020-01-01T00:00:00 | 100";
            Command command = Command.Parse(listEvent);
            Assert.AreEqual("ListEvents", command.CommandName);
            Assert.AreEqual("2020-01-01T00:00:00", command.Parameters[0]);
            Assert.AreEqual("100", command.Parameters[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvalidCommand()
        {
            string invalidCommand = "ListEvents2020-01-01T00:00:00|100";
            Command command = Command.Parse(invalidCommand);
        }
    }
}
