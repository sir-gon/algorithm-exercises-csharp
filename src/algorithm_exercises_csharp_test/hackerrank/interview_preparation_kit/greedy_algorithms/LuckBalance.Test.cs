namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.greedy_algorithms;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

[TestClass]
public class LuckBalanceTest
{
  public class LuckBalanceTestCase
  {
    public string title = "";
    public int k;
    public List<List<int>> contests = [];
    public int expected;
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
      result = LuckBalance.luckBalance(test.k, test.contests);
      Assert.AreEqual(
        test.expected,
        result,
        String.Format(
          "testLuckBalance({0}, {1}) => must be: {2}",
          test.k,
          test.contests.ToString(),
          test.expected
        )
      );
    }
  }
}
