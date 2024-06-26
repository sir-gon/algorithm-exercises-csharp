namespace algorithm_exercises_csharp.hackerrank;

[TestClass]
public class BirthdayCakeCandlesTest
{
  public class BirthdayCakeCandlesTestCase
  {
    public List<int> input = [];
    public int expected = 0;
  }

  private static readonly BirthdayCakeCandlesTestCase[] tests = [
    new() { input = [3, 2, 1, 3], expected = 2 },
    new() { input = [1, 2, 3, 3], expected = 2 }
  ];

  [TestMethod]
  public void testBirthdayCakeCandles()
  {
    int? result;

    foreach (BirthdayCakeCandlesTestCase test in tests)
    {
      result = BirthdayCakeCandles.birthdayCakeCandles(test.input);
      Assert.AreEqual(test.expected, result);
    }
  }

  [TestMethod]
  public void testMiniMaxSumEmptyInput()
  {
    Assert.ThrowsException<ArgumentException>(() => BirthdayCakeCandles.birthdayCakeCandles([]));
  }
}

