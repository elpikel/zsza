using System.Linq;
using Xunit;

namespace zsza
{
  public class Unit4
  {
    [Theory]
    [InlineData(new [] { 1, 4, 3, 2, 5}, 60)]
    [InlineData(new [] { -2, 1, 1, 5 }, 5)]
    public void ProductTest(int [] numbers, int result)
    {
      Assert.Equal(result, BiggestProduct(numbers));
    }

    private int BiggestProduct(int[] numbers)
    {
      return numbers
        .OrderByDescending(n => n)
        .Take(3)
        .Aggregate((a, b) => a * b);
    }
  }
}
