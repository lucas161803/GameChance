using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using budgetTest;

namespace GameChanceTest.GameChance
{
    public static class Extensions
    {
        public static IEnumerable AggregateProbabilities(this IEnumerable<int> data)
        {
            var aggregate = 0;
            foreach (var probability in data) yield return aggregate += probability;
        }

        public static IEnumerable<string> ControlRoomSelect(this List<ControlRow> controlRows, IRandom random)
        {
            if (controlRows == null || controlRows.Count == 0)
                throw new ArgumentNullException("機率表錯誤: Control");
            return controlRows
                .Where(controlRow => random.Next(0, 512) < controlRow.Probability)
                .Select(controlRow => controlRow.ProjectId);
        }
    }
}