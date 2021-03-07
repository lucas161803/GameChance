using System;
using System.Collections.Generic;
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
        public void probability_512_and_sgame_is_project1()
        {
            SgameShouldBe("project1", new List<string>());
        }

        [Test]
        public void input_100_get_row_probability_512_and_sgame_is_project2()
        {
            var roomIds = new List<string> {"100"};

            SgameShouldBe("project2", roomIds);
        }

        private void SgameShouldBe(string expected, List<string> roomIds)
        {
            var query = _roomSelector.Query(roomIds);
            Assert.AreEqual(expected, query);
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