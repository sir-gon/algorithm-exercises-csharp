// @link Problem definition [[docs/hackerrank/projecteuler/euler003.md]]
// Notes about final solution please see:
// @link [[docs/hackerrank/projecteuler/euler003-solution-notes.md]]

namespace algorithm_exercises_csharp.hackerrank.projecteuler;

using System.Diagnostics.CodeAnalysis;

public static class Euler003
{
  public static int? primeFactor(int n)
  {
    if (n < 2)
    {
      return null;
    }

    int divisor = n;
    int? max_prime_factor = null;

    int i = 2;
    while (i <= Math.Sqrt(divisor))
    {
      if (divisor % i == 0)
      {
        divisor = divisor / i;
        max_prime_factor = divisor;
      }
      else
      {
        i += 1;
      }
    }

    if (max_prime_factor is null)
    {
      return n;
    }

    return max_prime_factor;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int? euler003(int n)
  {
    return primeFactor(n);
  }
}
