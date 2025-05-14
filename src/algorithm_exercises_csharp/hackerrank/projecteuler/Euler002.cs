// @link Problem definition [[docs/hackerrank/projecteuler/euler002.md]]

namespace algorithm_exercises_csharp.hackerrank.projecteuler;

using System.Diagnostics.CodeAnalysis;

public static class Euler002
{
  public static int fiboEvenSum(int n)
  {
    Log.info("fiboEvenSum({n})", n);

    int i = 0;
    int even_sum = 0;
    int fibo;
    int fibo1 = 1;
    int fibo2 = 1;

    while (fibo1 + fibo2 < n)
    {
      fibo = fibo1 + fibo2;

      Log.info("Fibonacci({i}) = {fibo}", i, fibo);

      if (fibo % 2 == 0)
      {
        even_sum += fibo;
      }

      fibo1 = fibo2;
      fibo2 = fibo;
      i += 1;
    }

    Log.info("Problem 0002 result: {even_sum}", even_sum);

    return even_sum;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int euler002(int n)
  {
    return fiboEvenSum(n);
  }
}
