// @link Problem definition [[docs/hackerrank/projecteuler/euler001.md]]

namespace algorithm_exercises_csharp.hackerrank.projecteuler;

using System.Diagnostics.CodeAnalysis;

public class Euler001
{
  [ExcludeFromCodeCoverage]
  protected Euler001() { }

  public static int sumOfArithmeticProgression(int n, int d)
  {
    int new_n = n / d;

    return new_n * (1 + new_n) * d / 2;
  }

  public static int gcd(int u, int v)
  {
    if (v != 0)
    {
      return gcd(v, u % v);
    }
    return u;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int euler001(int a, int b, int n)
  {
    // Since, we need the sum of multiples less than N
    int new_n = n - 1;
    int lcm = a * b / gcd(a, b);

    return sumOfArithmeticProgression(new_n, a) +
      sumOfArithmeticProgression(new_n, b) -
      sumOfArithmeticProgression(new_n, lcm);
  }
}
