namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

[TestClass]
public class MinimumAbsoluteDifferenceInAnArrayTest
{
  public class MinimumAbsoluteDifferenceInAnArrayTestCase(string title, List<int> input, int expected)
  {
    public string Title { get; } = title;
    public List<int> Input { get; } = [.. input];
    public int Expected { get; } = expected;
  }

  private List<MinimumAbsoluteDifferenceInAnArrayTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<MinimumAbsoluteDifferenceInAnArrayTestCase>>(
      "hackerrank/interview_preparation_kit/greedy_algorithms/minimum_absolute_difference_in_an_array.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testMinimumAbsoluteDifferenceInAnArray()
  {
    int result;

    foreach (MinimumAbsoluteDifferenceInAnArrayTestCase test in testCases)
    {
      result = MinimumAbsoluteDifferenceInAnArray.minimumAbsoluteDifference(test.Input);
      Assert.AreEqual(
        test.Expected,
        result,
        string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "minimumAbsoluteDifference({0}) => must be: {1}",
          test.Input.ToString(),
          test.Expected
        )
      );
    }
  }
}
