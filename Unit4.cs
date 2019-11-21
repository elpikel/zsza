using System;
using System.Collections.Generic;
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

    [Theory]
    [InlineData(2, new [] {3, 3, 2, 3, 4, 5}, 5)]
    public void NailsTest(int hits, int [] nails, int result)
    {
      Assert.Equal(result, MaximumNumberOfNailsOnOneHeigh(hits, nails));
    }

    private int MaximumNumberOfNailsOnOneHeigh(int hits, int[] nails)
    {
      var sortedNail = nails
        .OrderByDescending(n => n)
        .ToList();
      var numberOfNailsOnOneHeigh = 1;
      var height = sortedNail[0] - hits;

      for (int i = 1; i < nails.Length; i++)
      {
        if (sortedNail[i] >= height)
          numberOfNailsOnOneHeigh += 1;
        else
          break;
      }

      return numberOfNailsOnOneHeigh;
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
