namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.miscellaneous;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

[TestClass]
public class TimeComplexityPrimalityTest
{
  public class TimeComplexityPrimalityTestCaseTest(int input, String answer)
  {
    public int Input { get; } = input;
    public String Answer { get; } = answer;
  }

  public class TimeComplexityPrimalityTestCase(string title, List<TimeComplexityPrimalityTestCaseTest> tests)
  {
    public string Title { get; } = title;
    public List<TimeComplexityPrimalityTestCaseTest> Tests { get; } = tests;
  }

  private List<TimeComplexityPrimalityTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<TimeComplexityPrimalityTestCase>>(
      "hackerrank/interview_preparation_kit/miscellaneous/ctci_big_o.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testTimeComplexityPrimality()
  {
    foreach (TimeComplexityPrimalityTestCase tests in testCases)
    {
      foreach (TimeComplexityPrimalityTestCaseTest test in tests.Tests)
      {
        String result = TimeComplexityPrimality.primality(test.Input);

        Assert.AreEqual(
          test.Answer,
          result,
          string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "TimeComplexityPrimality.primality({0}) => must be: {1}",
            test.Input,
            test.Answer
          )
        );
      }
    }
  }
}
