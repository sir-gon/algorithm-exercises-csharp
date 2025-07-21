namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.miscellaneous;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

[TestClass]
public class FlippingBitsAlternativeTest
{
  public class FlippingBitsAlternativeTestCaseTest(long input, long answer)
  {
    public long Input { get; } = input;
    public long Answer { get; } = answer;
  }

  public class FlippingBitsAlternativeTestCase(string title, List<FlippingBitsAlternativeTestCaseTest> tests)
  {
    public string Title { get; } = title;
    public List<FlippingBitsAlternativeTestCaseTest> Tests { get; } = tests;
  }

  private List<FlippingBitsAlternativeTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<FlippingBitsAlternativeTestCase>>(
      "hackerrank/interview_preparation_kit/miscellaneous/flipping_bits.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testFlippingBitsAlternative()
  {
    long result;

    foreach (FlippingBitsAlternativeTestCase tests in testCases)
    {
      foreach (FlippingBitsAlternativeTestCaseTest test in tests.Tests)
      {
        result = FlippingBitsAlternative.flippingBits(test.Input);
        Assert.AreEqual(
          test.Answer,
          result,
          string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "FlippingBitsAlternative.flippingBits({0}) => must be: {1}",
            test.Input,
            test.Answer
          )
        );
      }
    }
  }
}
