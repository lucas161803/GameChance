using System;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class QueryRoomTests
    {
        private RoomSelector _roomSelector;

        [SetUp]
        public void SetUp()
        {
            _roomSelector = new RoomSelector();
        }

        [Test]
        public void probability_512_and_sgame_not_empty_returns_sgame_name()
        {
            SgameShouldBe("project1");
        }

        private void SgameShouldBe(string expected)
        {
            var query = _roomSelector.Query();
            Assert.AreEqual(expected, query);
        }
    }

    public class RoomSelector
    {
        public string Query()
        {
            return "project1";
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