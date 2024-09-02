namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

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

  private static readonly LuckBalanceTestCase[] tests = [
    new()
    {
      title = "Sample Test case 0",
      k = 3,
      contests = [[5, 1], [2, 1], [1, 1], [8, 1], [10, 0], [5, 0]],
      expected = 29
    },
    new()
    {
      title = "Sample Test case 1",
      k = 5,
      contests = [[13, 1], [10, 1], [9, 1], [8, 1], [13, 1], [12, 1], [18, 1], [13, 1]],
      expected = 42
    },
    new()
    {
      title = "Sample Test case 2",
      k = 2,
      contests = [[5, 1], [4, 0], [6, 1], [2, 1], [8, 0]],
      expected = 21
    }
  ];

  [TestMethod]
  public void testLuckBalance()
  {
    int result;

    foreach (LuckBalanceTestCase test in tests)
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
