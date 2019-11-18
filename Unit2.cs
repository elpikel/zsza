using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace zsza
{
  public class Unit2
    {
        [Theory]
        [InlineData(5, new [] { 1, 4, 3, 2, 5 }, "TAK")]
        [InlineData(5, new [] { 1, 4, 3, 3, 5 }, "NIE")]
        public void Permutations(int n, int [] numbers, string result)
        {
            Assert.Equal(result, IsPermutation(n, numbers));
        }

        [Theory]
        [InlineData(5, 8, new [] { 1, 3, 1, 4, 2, 3, 5, 4 }, 7)]
        [InlineData(5, 8, new [] { 1, 3, 1, 4, 2, 3, 4, 5 }, 8)]
        [InlineData(3, 8, new [] { 1, 3, 1, 3, 2, 3, 1, 1 }, 5)]
        public void Toad(int position, int leaves, int [] leavePositions, int result)
        {
            Assert.Equal(result, CalculateLeavesNumber(position, leaves, leavePositions));
        }

        [Theory]
        [InlineData(5, 7, new [] { 3, 4, 4, 6, 1, 4, 4 }, new [] { 3, 2, 2, 4, 2 })]
        public void Buttons(int counters, int pushesCount, int [] pushes, int [] result)
        {
            Assert.Equal(result, CalculateCounters(counters, pushesCount, pushes));
        }

        private int[] CalculateCounters(int counters, int pushesCount, int[] pushes)
        {
            var counts = new int[counters + 1];
            var max = 0;
            var allMax = 0;

            for (int i = 0; i < pushesCount; i++) {
                if (pushes[i] == counters + 1)
                {
                    allMax = max;
                    continue;
                }

                if (allMax > counts[pushes[i]])
                    counts[pushes[i]] = allMax + 1;
                else
                    counts[pushes[i]] += 1;

                if (counts[pushes[i]] > max)
                    max = counts[pushes[i]];
            }

            return counts
                .Select(c => c > allMax ? c : allMax)
                .Skip(1)
                .ToArray();
        }

        private int CalculateLeavesNumber(int position, int leaves, int[] leavePositions)
        {
            var counts = new int[position + 1];
            var positions = 0;

            for (int i = 0; i < leaves; i++) {
                counts[leavePositions[i]] += 1;

                if (counts[leavePositions[i]] == 1)
                    positions += 1;

                if (positions == position)
                    return i + 1;
            }

            return -1;
        }

        private string IsPermutation(int n, int [] numbers)
        {
            var counts = new int[n + 1];

            for (int i = 0; i < n; i++) {
                counts[numbers[i]] += 1;

                if (counts[numbers[i]] > 1)
                    return "NIE";
            }

            return "TAK";
        }
    }
}
