using System;
using System.Collections.Generic;
using Xunit;

namespace zsza
{
  public class Unit5
  {
    private class Fish
    {
      public int Weight { get; }
      public int Direction { get; }

      public Fish(int weight, int direction)
      {
        Direction = direction;
        Weight = weight;
      }
    }

    [Theory]
    [InlineData(new[] { '{', '[', '(', ')', '(', ')', ']', '}' }, "TAK")]
    [InlineData(new[] { '(', '[', ')', '(', ')', ']' }, "NIE")]
    public void BracketsTest(char[] brackets, string result)
    {
      Assert.Equal(result, CorrectBrackets(brackets));
    }

    [Theory]
    [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }, 2)]
    public void FishesTest(int[] fishesWeight, int[] fishesDirection, int result)
    {
      Assert.Equal(result, LeftFishes(fishesWeight, fishesDirection));
    }

    private int LeftFishes(int[] fishesWeight, int[] fishesDirection)
    {
      var fishesStack = new Stack<Fish>();

      for (int i = 0; i < fishesWeight.Length; i++)
        AddFish(fishesStack, new Fish(fishesWeight[i], fishesDirection[i]));

      return fishesStack.Count;
    }

    private void AddFish(Stack<Fish> fishes, Fish fish)
    {
      if (fishes.Count == 0)
      {
        fishes.Push(fish);
        return;
      }

      var lastFish = fishes.Peek();

      if (lastFish.Direction == 1 && fish.Direction == 0)
      {
        if (lastFish.Weight > fish.Weight)
        {
          return;
        }
        else
        {
          fishes.Pop();
          AddFish(fishes, fish);
          return;
        }
      }

      fishes.Push(fish);
    }

    private string CorrectBrackets(char[] brackets)
    {
      var bracketsStack = new Stack<char>();
      bracketsStack.Push(brackets[0]);

      for (int i = 1; i < brackets.Length; i++)
      {
        var previousBracket = bracketsStack.Peek();
        if (Matches(previousBracket, brackets[i]))
          bracketsStack.Pop();
        else
          bracketsStack.Push(brackets[i]);
      }

      return bracketsStack.Count == 0 ? "TAK" : "NIE";
    }

    private bool Matches(char previousBracket, char bracket)
    {
      return (previousBracket == '(' && bracket == ')') ||
        (previousBracket == '[' && bracket == ']') ||
        (previousBracket == '{' && bracket == '}');
    }
  }
}
