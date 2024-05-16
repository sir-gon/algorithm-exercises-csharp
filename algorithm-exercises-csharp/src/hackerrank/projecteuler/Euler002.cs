// @link Problem definition [[docs/hackerrank/projecteuler/euler002.md]]

namespace algorithm_exercises_csharp.hackerrank.projecteuler;

using System.Diagnostics.CodeAnalysis;

public class Euler002
{
  [ExcludeFromCodeCoverage]
  protected Euler002() { }

  public static int fiboEvenSum(int n)
  {
    int total = 0;
    int fibo;
    int fibo1 = 1;
    int fibo2 = 1;

    while (fibo1 + fibo2 < n)
    {
      fibo = fibo1 + fibo2;
      fibo1 = fibo2;
      fibo2 = fibo;

      if (fibo % 2 == 0)
      {
        total += fibo;
      }
    }

    return total;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int euler002(int n)
  {
    return fiboEvenSum(n);
  }
}
