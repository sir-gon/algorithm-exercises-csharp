namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.miscellaneous;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.miscellaneous;

[TestClass]
public class FlippingBitsTest
{
  public class FlippingBitsTestCaseTest(long input, long answer)
  {
    public long Input { get; } = input;
    public long Answer { get; } = answer;
  }

  public class FlippingBitsTestCase(string title, List<FlippingBitsTestCaseTest> tests)
  {
    public string Title { get; } = title;
    public List<FlippingBitsTestCaseTest> Tests { get; } = tests;
  }

  private List<FlippingBitsTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<FlippingBitsTestCase>>(
      "hackerrank/interview_preparation_kit/miscellaneous/flipping_bits.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testFlippingBits()
  {
    long result;

    foreach (FlippingBitsTestCase tests in testCases)
    {
      foreach (FlippingBitsTestCaseTest test in tests.Tests)
      {
        result = FlippingBits.flippingBits(test.Input);
        Assert.AreEqual(
          test.Answer,
          result,
          string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "FlippingBits.flippingBits({0}) => must be: {1}",
            test.Input,
            test.Answer
          )
        );
      }
    }
  }
}
