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

        [Theory]
        [InlineData(5, new int [] { 0, 1, 0, 1, 1 }, 5)]
        public void Cars(int numberOfCars, int[] cars, int result)
        {
            Assert.Equal(result, GetPassedCars(cars));
        }

        private int GetPassedCars(int[] numbers)
        {
            var passedCars = 0;
            var carsGoingIntoOppositeDirection = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 0)
                    carsGoingIntoOppositeDirection += 1;
                if(numbers[i] == 1)
                    passedCars += carsGoingIntoOppositeDirection;
            }

            return passedCars;
        }

        private decimal GetSmallestAverageArithmetic(int[] numbers)
        {
            return numbers.Min();
        }
  }
}
