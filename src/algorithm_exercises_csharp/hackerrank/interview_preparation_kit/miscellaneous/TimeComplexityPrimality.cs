// @link Problem definition [[docs/hackerrank/interview_preparation_kit/miscellaneous/ctci-big-o.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

using System.Diagnostics.CodeAnalysis;
using System.Text;


public static class TimeComplexityPrimality
{
  private const string PRIME = "Prime";
  private const string NOT_PRIME = "Not prime";


  private static Int32? primeFactor(int n)
  {
    if (n < 2)
    {
      return null;
    }

    int divisor = n;
    Int32? maxPrimeFactor = null;
    int i = 2;
    while (i <= Math.Sqrt(divisor))
    {
      if (divisor % i == 0)
      {
        divisor = divisor / i;
        maxPrimeFactor = i;
      }
      else
      {
        i += 1;
      }
    }

    if (maxPrimeFactor == null)
    {
      return n;
    }

    return maxPrimeFactor;
  }


  /**
   * primality.
   */
  public static string primality(int n)
  {
    Int32? pf = primeFactor(n);

    return (pf == null || pf != n) ? NOT_PRIME : PRIME;
  }
}
