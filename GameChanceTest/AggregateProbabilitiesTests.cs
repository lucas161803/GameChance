using System;
using System.Collections.Generic;
using GameChanceTest.GameChance;
using NUnit.Framework;

namespace GameChanceTest
{
    public class AggregateProbabilitiesTests
    {
        [Test]
        public void zero_element_returns_empty_list()
        {
            CollectionAssert.AreEqual(new List<int>(), Array.Empty<int>().AggregateProbabilities());
        }

        [Test]
        public void one_element_returns_itself()
        {
            CollectionAssert.AreEqual(new List<int> {4}, new[] {4}.AggregateProbabilities());
        }

        [Test]
        public void array_0_1_returns_0_1()
        {
            CollectionAssert.AreEqual(new List<int> {0, 1}, new[] {0, 1}.AggregateProbabilities());
        }

        [Test]
        public void array_1_2_returns_1_3()
        {
            CollectionAssert.AreEqual(new List<int> {1, 3}, new[] {1, 2}.AggregateProbabilities());
        }

        [Test]
        public void array_1_2_3_returns_1_3_6()
        {
            CollectionAssert.AreEqual(new List<int> {1, 3, 6}, new[] {1, 2, 3}.AggregateProbabilities());
        }
    }
}