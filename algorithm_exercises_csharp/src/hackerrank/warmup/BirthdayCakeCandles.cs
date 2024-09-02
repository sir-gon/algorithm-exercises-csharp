// @link Problem definition [[docs/hackerrank/warmup/birthday_cake_candles.md]]

namespace algorithm_exercises_csharp.hackerrank;

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

public class BirthdayCakeCandles
{
  [ExcludeFromCodeCoverage]
  protected BirthdayCakeCandles() { }

  public static int birthdayCakeCandles(List<int> _arr)
  {
    if (_arr.Count == 0)
    {
      throw new ArgumentException("Parameter cannot be empty", nameof(_arr));
    }

    int counter = 0;
    int maximum = _arr[0];

    foreach (int element in _arr)
    {
      if (element > maximum)
      {
        maximum = element;
        counter = 1;
      }
      else
      {
        if (element == maximum)
        {
          counter += 1;
        }
      }
    }

    return counter;
  }
}
