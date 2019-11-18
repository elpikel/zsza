using System;
using System.Linq;
using Xunit;

namespace zsza
{
    public class Unit1
    {
        [Theory]
        [InlineData(10, 85, 30, 3)]
        [InlineData(10, 11, 30, 1)]
        public void Frog(int start, int end, int jump, int result)
        {
            var jumps = Math.Ceiling((end - start) / (double)jump);

            Assert.Equal(result, jumps);
        }

        [Theory]
        [InlineData(5, new [] { 2, 3, 1, 5 }, 4)]
        [InlineData(10, new [] { 2, 3, 1, 5, 9, 7, 6, 8, 10 }, 4)]
        public void Sidewalk(int n, int[] numbers, int result)
        {
            var sumOfNNumbers = n * (n + 1) / 2;
            var sumOfNumbers = numbers.Sum();
            var missingNumber = sumOfNNumbers - sumOfNumbers;

            Assert.Equal(result, missingNumber);
        }

        [Theory]
        [InlineData(5, new [] { 3, 1, 2, 4, 3 }, 1)]
        public void Tapes(int n, int[] numbers, int result)
        {
            var sumSoFar = 0;
            int? distance = null;
            var sumOfNumbers = numbers.Sum();
            for (int i = 0; i < numbers.Length; i++)
            {
                sumSoFar += numbers[i];
                var remainingSum = sumOfNumbers - sumSoFar;
                var newDistance = Distance(sumSoFar, remainingSum);

                if (distance != null && newDistance >= distance)
                    break;

                distance = newDistance;
            }

            Assert.Equal(result, distance);
        }

        private int Distance(int a, int b)
        {
            return Math.Abs(a - b);
        }
    }
}
