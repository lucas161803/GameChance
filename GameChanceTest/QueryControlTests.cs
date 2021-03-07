using System;
using System.Collections.Generic;
using System.Linq;
using GameChanceTest.GameChance;
using NSubstitute;
using NUnit.Framework;

namespace GameChanceTest
{
    [TestFixture]
    public class QueryControlTests
    {
        [SetUp]
        public void SetUp()
        {
            _controlRepo = Substitute.For<IControlRepo>();
            _random = Substitute.For<FakeRandom>();
        }

        private IControlRepo _controlRepo;
        private FakeRandom _random;

        [Test]
        public void data_null_throw_exception()
        {
            Assert.Throws<ArgumentNullException>(() => RoomShouldBe(null));
        }

        [Test]
        public void probability_512_returns_first()
        {
            GivenControl(new ControlRow {ProjectId = "108", Probability = 512});
            GivenTestRandomNumbers(0);
            RoomShouldBe("108");
        }

        [Test]
        public void probability_1_512_random_num_0_512_return_first()
        {
            GivenControl(
                new ControlRow {ProjectId = "107", Probability = 1},
                new ControlRow {ProjectId = "108", Probability = 512}
            );
            GivenTestRandomNumbers(0, 512);
            RoomShouldBe("107");
        }

        [Test]
        public void probability_1_512_random_num_1_2_return_second()
        {
            GivenControl(
                new ControlRow {ProjectId = "107", Probability = 1},
                new ControlRow {ProjectId = "108", Probability = 512}
            );
            GivenTestRandomNumbers(1, 2);
            RoomShouldBe("108");
        }

        [Test]
        public void probability_1_10_512_random_num_1_2_512_return_second()
        {
            GivenControl(
                new ControlRow {ProjectId = "106", Probability = 1},
                new ControlRow {ProjectId = "107", Probability = 10},
                new ControlRow {ProjectId = "108", Probability = 512}
            );
            GivenTestRandomNumbers(1, 2, 512);
            RoomShouldBe("107");
        }

        [Test]
        public void probability_1_2_512_random_num_1_2_511_return_third()
        {
            GivenControl(
                new ControlRow {ProjectId = "106", Probability = 1},
                new ControlRow {ProjectId = "107", Probability = 2},
                new ControlRow {ProjectId = "108", Probability = 512}
            );
            GivenTestRandomNumbers(1, 2, 511);
            RoomShouldBe("108");
        }

        private void GivenTestRandomNumbers(params int[] numbers)
        {
            _random.RandomNumbers = numbers;
        }

        private void GivenControl(params ControlRow[] controlRows)
        {
            _controlRepo.Get().ReturnsForAnyArgs(controlRows.ToList());
        }

        private void RoomShouldBe(params string[] expected)
        {
            var controlRows = _controlRepo.Get();
            Assert.AreEqual(expected, controlRows.QueryControl(_random));
        }
    }

    public interface IControlRepo
    {
        List<ControlRow> Get();
    }

    public abstract class FakeRandom : IRandom
    {
        private int _nowIndex;
        public int[] RandomNumbers { get; set; }

        public int Next(int min, int max)
        {
            return RandomNumbers[_nowIndex++];
        }
    }
}