using System;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class QueryRoomTests
    {
        [Test]
        public void probability_512_and_sgame_not_empty_returns_sgame_name()
        {
            var roomSelector = new RoomSelector();
            var query = roomSelector.Query();
            Assert.AreEqual("project1", query);
        }
    }

    public class RoomSelector
    {
        public string Query()
        {
            throw new System.NotImplementedException();
        }
    }

    public class RoomRow
    {
        public string ProjectId { get; set; }
        public int Probability { get; set; }
        public string Room { get; set; }
        public string Sgame { get; set; }
    }
}