using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace zsza
{
  public class Unit4
  {
    private class Coordinate
    {
      public int X { get; }
      public int Y { get; }

      public Coordinate(int x, int y)
      {
        X = x;
        Y = y;
      }

      public int GetDistance(Coordinate coordinate)
      {
        return X + coordinate.X + Math.Abs(Y - coordinate.Y);
      }
    }

    [Theory]
    [InlineData(new[] { 1, 4, 3, 2, 5 }, 60)]
    [InlineData(new[] { -2, 1, 1, 5 }, 5)]
    public void ProductTest(int[] numbers, int result)
    {
      Assert.Equal(result, BiggestProduct(numbers));
    }

    [Theory]
    [InlineData(2, new[] { 3, 3, 2, 3, 4, 5 }, 5)]
    public void NailsTest(int hits, int[] nails, int result)
    {
      Assert.Equal(result, MaximumNumberOfNailsOnOneHeigh(hits, nails));
    }

    [Fact]
    public void RailwaysTest()
    {
      var houses = new Coordinate[] { new Coordinate(1, 1), new Coordinate(2, 2), new Coordinate(3, 3) };
      Assert.Equal(4, GetMinimumDistance(houses));
    }

    private int GetMinimumDistance(Coordinate[] houses)
    {
      var sortedHouses = houses
        .OrderBy(h => h.X)
        .OrderBy(h => h.Y)
        .ToList();
      var smallestDistance = int.MaxValue;

      for (int i = 1; i < sortedHouses.Count; i++)
      {
        var distance = sortedHouses[i - 1].GetDistance(sortedHouses[i]);
        if (distance < smallestDistance)
          smallestDistance = distance;
      }

      return smallestDistance;
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
