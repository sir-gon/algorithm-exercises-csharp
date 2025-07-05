// @link Problem definition [[docs/hackerrank/interview_preparation_kit/miscellaneous/flipping-bits.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

using System.Diagnostics.CodeAnalysis;
using System.Text;

public static class FlippingBits
{
  public static long flippingBits(long n)
  {
    string n_bin_str = Convert.ToString(n, 2);
    n_bin_str = n_bin_str.PadLeft(32, '0'); // Ensure 32 bits
    StringBuilder result_bin_str = new StringBuilder();

    foreach (char bin_digit in n_bin_str)
    {
      if (bin_digit == '1')
      {
        result_bin_str.Append('0');
      }
      else
      {
        result_bin_str.Append('1');
      }
    }

    long number = Convert.ToUInt32(result_bin_str.ToString(), 2);

    return number;
  }
}
