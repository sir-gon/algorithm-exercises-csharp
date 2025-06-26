namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

/**
 * GreedyFloristTest.
 */
[TestClass]
public class GreedyFloristTest
{
  public class GreedyFloristTestCase(string title, List<int> c, int k, int expected)
  {
    public string Title { get; } = title;
    public List<int> C { get; } = c;
    public int K { get; } = k;
    public int Expected { get; } = expected;
  }

  private List<GreedyFloristTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<GreedyFloristTestCase>>(
      "hackerrank/interview_preparation_kit/greedy_algorithms/greedy_florist.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testLuckBalance()
  {
    foreach (GreedyFloristTestCase test in testCases)
    {
      int[] inputArray = test.C.ToArray();
      int result = GreedyFlorist.getMinimumCost(test.K, inputArray);

      Assert.AreEqual(
        test.Expected,
        result,
        string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "getMinimumCost({0}, {1}) => must be: {2}",
          test.K,
          inputArray.ToString(),
          test.Expected
        )
      );
    }
  }
}
