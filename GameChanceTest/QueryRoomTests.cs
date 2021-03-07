using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class QueryRoomTests
    {
        private RoomSelector _roomSelector;
        private List<string> _roomIds;
        private IRoomRepo _roomRepo;

        [SetUp]
        public void SetUp()
        {
            _roomSelector = new RoomSelector();
            _roomRepo = Substitute.For<IRoomRepo>();
        }

        [Test]
        public void input_0_get_row_probability_512_and_sgame_is_project1()
        {
            GivenRoomIdList("0");
            GivenRoomTable("0", new RoomRow() {ProjectId = "0", Sgame = "project1"});
            SgameShouldBe("project1");
        }

        [Test]
        public void input_1_get_row_probability_512_and_sgame_is_project2()
        {
            GivenRoomIdList("1");
            GivenRoomTable("1", new RoomRow() {ProjectId = "1", Sgame = "project2"});
            SgameShouldBe("project2");
        }

        private void GivenRoomTable(string projectId, params RoomRow[] roomRows)
        {
            _roomRepo.Get().ReturnsForAnyArgs(new Dictionary<string, List<RoomRow>>
            {
                [projectId] = roomRows.ToList(),
            });
        }

        private void GivenRoomIdList(params string[] roomIds)
        {
            _roomIds = roomIds.ToList();
        }

        private void SgameShouldBe(string expected)
        {
            var roomTable = _roomRepo.Get();
            var query = _roomSelector.Query(_roomIds, roomTable);
            Assert.AreEqual(expected, query);
        }
    }

    public interface IRoomRepo
    {
        Dictionary<string, List<RoomRow>> Get();
    }

    public class RoomRow
    {
        public string ProjectId { get; set; }
        public int Probability { get; set; }
        public string Room { get; set; }
        public string Sgame { get; set; }
    }
}