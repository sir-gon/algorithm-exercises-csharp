// @link Problem definition [[docs/hackerrank/projecteuler/euler003.md]]

namespace algorithm_exercises_csharp.hackerrank.prohecteuler;

using System.Diagnostics.CodeAnalysis;

public class Euler003Problem
{
  [ExcludeFromCodeCoverage]
  protected Euler003Problem() {}

  public static int? PrimeFactor(int n) {
    if (n < 2) {
      return null;
    }

    int divisor = n;
    int? max_prime_factor = null;

    int i = 2;
    while (i <= Math.Sqrt(divisor)) {
        if (0 == divisor % i) {
            divisor = divisor / i;
            max_prime_factor = divisor;
        } else {
          i += 1;
        }
    }

    if (max_prime_factor is null) {
      return n;
    }

    return max_prime_factor;
  }

  // Function to find the sum of all multiples of a and b below n
  public static int? Euler003(int n)
  {
    return PrimeFactor(n);
  }
}
