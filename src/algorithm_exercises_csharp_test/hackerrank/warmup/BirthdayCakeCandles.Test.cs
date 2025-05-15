namespace algorithm_exercises_csharp_test.hackerrank.warmup;

using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.common;

[TestClass]
public class BirthdayCakeCandlesTest
{
  public class BirthdayCakeCandlesTestCase(List<int> input, long expected)
  {
    private readonly List<int> input = input;
    private readonly long expected = expected;

    public List<int> Input
    {
      get { return input; }
    }

    public long Expected
    {
      get { return expected; }
    }
  }

  private List<BirthdayCakeCandlesTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<BirthdayCakeCandlesTestCase>>(/*lang=json,strict*/ @"
      [
        { ""input"": [3, 2, 1, 3], ""expected"": 2 },
        { ""input"": [1, 2, 3, 3], ""expected"": 2 }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testBirthdayCakeCandles()
  {
    long? result;

    foreach (BirthdayCakeCandlesTestCase test in testCases)
    {
      result = BirthdayCakeCandles.birthdayCakeCandles(test.Input);
      Assert.AreEqual(test.Expected, result);
    }
  }

  [TestMethod]
  public void testMiniMaxSumEmptyInput()
  {
    Assert.ThrowsExactly<ArgumentException>(() => _ = BirthdayCakeCandles.birthdayCakeCandles([]));
  }
}

