namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

[TestClass]
public class MinimumAbsoluteDifferenceInAnArrayTest
{
  public class MinimumAbsoluteDifferenceInAnArrayTestCase
  {
    public string title = "";
    public List<int> input = [];
    public int expected;
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
      result = MinimumAbsoluteDifferenceInAnArray.minimumAbsoluteDifference(test.input);
      Assert.AreEqual(
        test.expected,
        result,
        String.Format(
          "minimumAbsoluteDifference({0}) => must be: {1}",
          test.input.ToString(),
          test.expected
        )
      );
    }
  }
}
