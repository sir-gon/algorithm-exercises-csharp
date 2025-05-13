namespace algorithm_exercises_csharp_test.hackerrank.warmup;
using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.lib;

[TestClass]
public class TimeConversionTest
{
  public class TimeConversionTestCase(string input, string expected)
  {
    private readonly string input = input;
    private readonly string expected = expected;

    public string Input
    {
      get { return input; }
    }

    public string Expected
    {
      get { return expected; }
    }
  }

  private List<TimeConversionTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<TimeConversionTestCase>>(/*lang=json,strict*/ @"
      [
        { ""input"": ""12:01:00PM"", ""expected"": ""12:01:00"" },
        { ""input"": ""12:01:00AM"", ""expected"": ""00:01:00"" }
      ]
    ") ?? [];
  }

  [TestMethod]
  public void testTimeConversion()
  {
    string? result;

    foreach (TimeConversionTestCase test in testCases)
    {
      result = TimeConversion.timeConversion(test.Input);
      Assert.AreEqual(test.Expected, result);
    }
  }
}

