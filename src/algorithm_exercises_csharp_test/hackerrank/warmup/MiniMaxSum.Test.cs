namespace algorithm_exercises_csharp_test.hackerrank.warmup;

using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.common;

[TestClass]
public class MiniMaxSumTest
{
  public class MiniMaxSumTestCase(List<int> input, string expected)
  {
    private readonly List<int> input = input;
    private readonly string expected = expected;

    public List<int> Input
    {
      get { return input; }
    }

    public string Expected
    {
      get { return expected; }
    }
  }

  private List<MiniMaxSumTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<MiniMaxSumTestCase>>(/*lang=json,strict*/ @"
      [
        { ""input"": [1, 2, 3, 4, 5], ""expected"": ""10 14"" },
        { ""input"": [5, 4, 3, 2, 1], ""expected"": ""10 14"" }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testMiniMaxSum()
  {
    string? result;

    foreach (MiniMaxSumTestCase test in testCases)
    {
      result = MiniMaxSum.miniMaxSum(test.Input);
      Assert.AreEqual(test.Expected, result);
    }
  }

  [TestMethod]
  public void testMiniMaxSumEmptyInput()
  {
    Assert.ThrowsExactly<ArgumentException>(() => _ = MiniMaxSum.miniMaxSum([]));
  }
}

