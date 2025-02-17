namespace algorithm_exercises_csharp_test.hackerrank.warmup;
using algorithm_exercises_csharp.hackerrank.warmup;

[TestClass]
public class TimeConversionTest
{
  public class TimeConversionTestCase
  {
    public string input = "";
    public string expected = "";
  }

  private static readonly TimeConversionTestCase[] tests = [
    new() { input = "12:01:00PM", expected = "12:01:00" },
    new() { input = "12:01:00AM", expected = "00:01:00" }
  ];

  [TestMethod]
  public void testTimeConversion()
  {
    string? result;

    foreach (TimeConversionTestCase test in tests)
    {
      result = TimeConversion.timeConversion(test.input);
      Assert.AreEqual(test.expected, result);
    }
  }
}

