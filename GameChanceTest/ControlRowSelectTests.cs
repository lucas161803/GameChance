using System;
using System.Collections;
using System.Collections.Generic;
using budgetTest;
using GameChanceTest.GameChance;
using NSubstitute;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class ControlRowSelectTests
    {
        [Test]
        public void data_null_throw_exception()
        {
            Assert.Throws<ArgumentNullException>(() => RoomShouldBe(null, null, null));
        }

        [Test]
        public void no_data_throw_exception_and_message()
        {
            Assert.Throws<ArgumentNullException>(() => RoomShouldBe(null, new List<ControlRow>(), null),
                "機率表Control錯誤");
        }

        [Test]
        public void one_row_512_returns_first()
        {
            RoomShouldBe(new[] {"108"}, new List<ControlRow>
            {
                new ControlRow {ProjectId = "108", Probability = 512}
            }, new[] {0});
        }

        [Test]
        public void two_rows_1_512_random_num_0_512_return_first()
        {
            RoomShouldBe(new[] {"107"}, new List<ControlRow>
            {
                new ControlRow {ProjectId = "107", Probability = 1},
                new ControlRow {ProjectId = "108", Probability = 512}
            }, new[] {0, 512});
        }

        [Test]
        public void two_rows_1_512_random_num_1_2_return_second()
        {
            RoomShouldBe(new[] {"108"}, new List<ControlRow>
            {
                new ControlRow {ProjectId = "107", Probability = 1},
                new ControlRow {ProjectId = "108", Probability = 512}
            }, new[] {1, 2});
        }

        [Test]
        public void three_rows_1_10_512_random_num_1_2_512_return_second()
        {
            RoomShouldBe(new[] {"107"}, new List<ControlRow>
            {
                new ControlRow {ProjectId = "106", Probability = 1},
                new ControlRow {ProjectId = "107", Probability = 10},
                new ControlRow {ProjectId = "108", Probability = 512}
            }, new[] {1, 2, 512});
        }

        [Test]
        public void three_rows_1_2_512_random_num_1_2_511_return_third()
        {
            RoomShouldBe(new[] {"108"}, new List<ControlRow>
            {
                new ControlRow {ProjectId = "106", Probability = 1},
                new ControlRow {ProjectId = "107", Probability = 2},
                new ControlRow {ProjectId = "108", Probability = 512}
            }, new[] {1, 2, 511});
        }

        private static void RoomShouldBe(IEnumerable<string> expected, List<ControlRow> controlRows,
            IEnumerable randoms)
        {
            Assert.AreEqual(expected, controlRows.ControlRoomSelect(Substitute.For<FakeRandom>(randoms)));
        }
    }

    public abstract class FakeRandom : IRandom
    {
        private readonly int[] _randomList;
        private int _nowIndex;

        protected FakeRandom(int[] randomList)
        {
            _randomList = randomList;
        }

        public int Next(int min, int max)
        {
            return _randomList[_nowIndex++];
        }
    }
}