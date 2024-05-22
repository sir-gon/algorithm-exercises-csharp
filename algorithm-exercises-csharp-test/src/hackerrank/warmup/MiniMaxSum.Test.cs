namespace algorithm_exercises_csharp.hackerrank;

[TestClass]
public class MiniMaxSumTest
{
  public class MiniMaxSumTestCase
  {
    public List<int> input = [];
    public string expected = "";
  }

  private static readonly MiniMaxSumTestCase[] tests = [
    new() { input = [1, 2, 3, 4, 5], expected = "10 14" },
    new() { input = [5, 4, 3, 2, 1], expected = "10 14" }
  ];

  [TestMethod]
  public void testMiniMaxSum()
  {
    string? result;

    foreach (MiniMaxSumTestCase test in tests)
    {
      result = MiniMaxSum.miniMaxSum(test.input);
      Assert.AreEqual(test.expected, result);
    }
  }
}

