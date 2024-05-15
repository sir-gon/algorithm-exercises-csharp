// @link Problem definition [[docs/hackerrank/projecteuler/euler001.md]]

namespace algorithm_exercises_csharp.hackerrank.prohecteuler;

using System.Diagnostics.CodeAnalysis;

public class Euler001Problem
{
  [ExcludeFromCodeCoverage]
  protected Euler001Problem() { }

  public static int SuOfArithmeticProgression(int n, int d)
  {
    int new_n = n / d;

    return new_n * (1 + new_n) * d / 2;
  }

  public static int GCD(int u, int v)
  {
    if (v != 0)
    {
      return GCD(v, u % v);
    }
    return u;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int Euler001(int a, int b, int n)
  {
    // Since, we need the sum of multiples less than N
    int new_n = n - 1;
    int lcm = a * b / GCD(a, b);

    return SuOfArithmeticProgression(new_n, a) +
      SuOfArithmeticProgression(new_n, b) -
      SuOfArithmeticProgression(new_n, lcm);
  }
}
