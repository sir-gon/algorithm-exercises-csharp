namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

[TestClass]
public class LuckBalanceTest
{
  public class LuckBalanceTestCase(string title, int k, List<List<int>> contests, int expected)
  {
    public string Title { get; } = title;
    public int K { get; } = k;
    public List<List<int>> Contests { get; } = contests;
    public int Expected { get; } = expected;
  }

  private List<LuckBalanceTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<LuckBalanceTestCase>>(
      "hackerrank/interview_preparation_kit/greedy_algorithms/luck_balance.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testLuckBalance()
  {
    int result;

    foreach (LuckBalanceTestCase test in testCases)
    {
      result = LuckBalance.luckBalance(test.K, test.Contests);
      Assert.AreEqual(
        test.Expected,
        result,
        string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "testLuckBalance({0}, {1}) => must be: {2}",
          test.K,
          test.Contests.ToString(),
          test.Expected
        )
      );
    }
  }
}
