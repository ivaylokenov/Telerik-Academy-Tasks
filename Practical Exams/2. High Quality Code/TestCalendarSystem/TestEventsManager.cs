using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;
using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestEventsManager
    {
        [TestMethod]
        public void TestAddEventWithoutLocation()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);

            int countTitles = manager.TitlesList.Count;
            int countDates = manager.DatesList.Count;

            Assert.AreEqual(1, countTitles);
            Assert.AreEqual(1, countDates);
        }

        [TestMethod]
        public void TestAddEventWithLocation()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);

            int countTitles = manager.TitlesList.Count;
            int countDates = manager.DatesList.Count;

            Assert.AreEqual(1, countTitles);
            Assert.AreEqual(1, countDates);
        }

        [TestMethod]
        public void TestAddEventDublicates()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);

            var countTitles = manager.TitlesList["Test event".ToLowerInvariant()];
            var countDates = manager.DatesList[now];

            Assert.AreEqual(2, countTitles.Count);
            Assert.AreEqual(2, countDates.Count);
        }

        [TestMethod]
        public void TestAddEventMultiple()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(1), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(2), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var countTitles = manager.TitlesList["Test event".ToLowerInvariant()];
            var countDates = manager.DatesList[now];

            Assert.AreEqual(2, countTitles.Count);
            Assert.AreEqual(2, countDates.Count);
            Assert.AreEqual(3, manager.TitlesList.Count);
            Assert.AreEqual(3, manager.DatesList.Count);
        }

        [TestMethod]
        public void TestDeleteEvent()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(1), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(2), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            int deleted = manager.DeleteEventsByTitle("Test event");

            Assert.AreEqual(2, deleted);
            Assert.AreEqual(2, manager.DatesList.Count);
            Assert.AreEqual(2, manager.TitlesList.Count);
        }

        [TestMethod]
        public void TestDeleteNoMatchingEvent()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(1), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(2), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            int deleted = manager.DeleteEventsByTitle("Nqma me");

            Assert.AreEqual(0, deleted);
            Assert.AreEqual(3, manager.DatesList.Count);
            Assert.AreEqual(3, manager.TitlesList.Count);
        }

        [TestMethod]
        public void TestDoubleDelete()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(1), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(2), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            int deleted = manager.DeleteEventsByTitle("Test event");
            int deletedAgain = manager.DeleteEventsByTitle("Test event");

            Assert.AreEqual(2, deleted);
            Assert.AreEqual(0, deletedAgain);
        }

        [TestMethod]
        public void TestListedElementsWithOneMatchAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now.AddHours(-10), "Test event", "Nqkade si");
            Event otherEvent = new Event(now, "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now, 10).ToList();

            Assert.AreEqual(1, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsWithOneMatchMoreThanCountAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now, 1).ToList();

            Assert.AreEqual(1, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsWithOneMatchEqualToCountAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now, 2).ToList();

            Assert.AreEqual(2, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsWithOneMatchLessThanCountAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now, 3).ToList();

            Assert.AreEqual(2, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsWithMultipleMatchLessThanCountAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now.AddHours(-30), 3).ToList();

            Assert.AreEqual(3, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsWithMultipleMatchMoreThanCountAndFewNonMatching()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now.AddHours(-30), 10).ToList();

            Assert.AreEqual(4, selected.Count);
        }

        [TestMethod]
        public void TestListedElementsNoMatch()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(-10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);

            var selected = manager.ListEvents(now.AddHours(10), 10).ToList();

            Assert.AreEqual(0, selected.Count);
        }

        [TestMethod]
        public void TestSortingByDate()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event", "Nqkade si");
            Event otherEvent = new Event(now.AddHours(10), "Test other event", "Nqkade si");
            Event anotherEvent = new Event(now.AddHours(20), "Test another event", "Nqkade si");
            Event mismatchedEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);
            manager.AddEvent(mismatchedEvent);

            var selected = manager.ListEvents(now, 10).ToList();

            Assert.AreEqual(3, selected.Count);
            Assert.AreEqual(anotherEvent, selected[2]);
            Assert.AreEqual(otherEvent, selected[1]);
            Assert.AreEqual(currentEvent, selected[0]);
        }

        [TestMethod]
        public void TestSortingByTitle()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "bTest event", "Nqkade si");
            Event otherEvent = new Event(now, "aTest other event", "Nqkade si");
            Event anotherEvent = new Event(now, "cTest another event", "Nqkade si");
            Event mismatchedEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);
            manager.AddEvent(mismatchedEvent);

            var selected = manager.ListEvents(now, 10).ToList();

            Assert.AreEqual(3, selected.Count);
            Assert.AreEqual(anotherEvent, selected[2]);
            Assert.AreEqual(otherEvent, selected[0]);
            Assert.AreEqual(currentEvent, selected[1]);
        }

        [TestMethod]
        public void TestSortingByLocation()
        {
            DateTime now = DateTime.Now;
            Event currentEvent = new Event(now, "Test event");
            Event otherEvent = new Event(now, "Test event", "aNqkade si");
            Event anotherEvent = new Event(now, "Test event", "bNqkade si");
            Event mismatchedEvent = new Event(now.AddHours(-20), "Test another event", "Nqkade si");
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(currentEvent);
            manager.AddEvent(otherEvent);
            manager.AddEvent(anotherEvent);
            manager.AddEvent(mismatchedEvent);

            var selected = manager.ListEvents(now, 10).ToList();

            Assert.AreEqual(3, selected.Count);
            Assert.AreEqual(anotherEvent, selected[2]);
            Assert.AreEqual(otherEvent, selected[1]);
            Assert.AreEqual(currentEvent, selected[0]);
        }
    }
}
