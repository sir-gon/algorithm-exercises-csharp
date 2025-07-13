// @link Problem definition [[docs/hackerrank/interview_preparation_kit/miscellaneous/flipping-bits.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

using System.Diagnostics.CodeAnalysis;
using System.Text;

public static class FlippingBits
{
  public static long flippingBits(long n)
  {
    string binaryString = Convert.ToString(n, 2);
    binaryString = binaryString.PadLeft(32, '0'); // Ensure 32 bits
    StringBuilder flippedBinaryString = new StringBuilder();

    foreach (char binaryDigit in binaryString)
    {
      if (binaryDigit == '1')
      {
        flippedBinaryString.Append('0');
      }
      else
      {
        flippedBinaryString.Append('1');
      }
    }

    long number = Convert.ToUInt32(flippedBinaryString.ToString(), 2);

    return number;
  }
}
