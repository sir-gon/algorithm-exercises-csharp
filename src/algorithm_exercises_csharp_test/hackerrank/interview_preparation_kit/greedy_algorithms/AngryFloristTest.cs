namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

/**
 * AngryFloristTest.
 */
[TestClass]
public class AngryFloristTest
{
  public class AngryFloristTestCase(string title, int k, List<int> arr, int expected)
  {
    public string Title { get; } = title;
    public int K { get; } = k;
    public List<int> Arr { get; } = arr;
    public int Expected { get; } = expected;
  }

  private List<AngryFloristTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<AngryFloristTestCase>>(
      "hackerrank/interview_preparation_kit/greedy_algorithms/angry_children.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testLuckBalance()
  {
    foreach (AngryFloristTestCase test in testCases)
    {
      int result = AngryFlorist.maxMin(test.K, test.Arr);

      Assert.AreEqual(
        test.Expected,
        result,
        string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "AngryFlorist.maxMin({0}, {1}) => must be: {2}",
          test.K,
          test.Arr.ToString(),
          test.Expected
        )
      );
    }
  }
}
