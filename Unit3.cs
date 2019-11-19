using System.Linq;
using Xunit;

namespace zsza
{
    public class Unit3
    {
        [Theory]
        [InlineData(7, new int [] { 3, 4, 2, 2, 2, 5, 8 }, 2)]
        public void LongTape(int amountOfNumbers, int[] numbers, decimal result)
        {
            Assert.Equal(result, GetSmallestAverageArithmetic(numbers));
        }

        private decimal GetSmallestAverageArithmetic(int[] numbers)
        {
            return numbers.Min();
        }
  }
}
