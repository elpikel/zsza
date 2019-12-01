using System;
using System.Collections.Generic;
using Xunit;

namespace zsza
{
  public class Unit5
  {
    [Theory]
    [InlineData(new [] {'{','[','(',')','(',')',']','}'}, "TAK")]
    [InlineData(new [] {'(','[',')','(',')',']'}, "NIE")]
    public void BracketsTest(char [] brackets, string result)
    {
      Assert.Equal(result, CorrectBrackets(brackets));
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
