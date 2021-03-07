using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class QueryRoomTests
    {
        private RoomSelector _roomSelector;
        private List<string> _roomIds;

        [SetUp]
        public void SetUp()
        {
            _roomSelector = new RoomSelector();
        }

        [Test]
        public void input_0_get_row_probability_512_and_sgame_is_project1()
        {
            GivenRoomIdList("0");
            SgameShouldBe("project1");
        }

        [Test]
        public void input_1_get_row_probability_512_and_sgame_is_project2()
        {
            GivenRoomIdList("1");
            SgameShouldBe("project2");
        }

        private void GivenRoomIdList(params string[] roomIds)
        {
            _roomIds = roomIds.ToList();
        }

        private void SgameShouldBe(string expected)
        {
            var query = _roomSelector.Query(_roomIds);
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