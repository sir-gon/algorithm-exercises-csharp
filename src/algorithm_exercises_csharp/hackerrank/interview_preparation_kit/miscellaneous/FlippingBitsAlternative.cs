// @link Problem definition [[docs/hackerrank/interview_preparation_kit/miscellaneous/flipping-bits.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

using System.Diagnostics.CodeAnalysis;
using System.Text;

public static class FlippingBitsAlternative
{
  public static long flippingBits(long n)
  {
    return ~n & 0xFFFFFFFF; // Use bitwise NOT and mask to ensure 32 bits
  }
}
