using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameChanceTest.GameChance
{
    public static class Extensions
    {
        public static IEnumerable AggregateProbabilities(this IEnumerable<int> data)
        {
            var aggregate = 0;
            foreach (var probability in data) yield return aggregate += probability;
        }

        public static IEnumerable QueryControl(this IEnumerable<ControlRow> controlRows, IRandom random)
        {
            return controlRows
                .Where(controlRow => random.Next(0, 512) < controlRow.Probability)
                .Select(controlRow => controlRow.ProjectId);
        }
    }
}