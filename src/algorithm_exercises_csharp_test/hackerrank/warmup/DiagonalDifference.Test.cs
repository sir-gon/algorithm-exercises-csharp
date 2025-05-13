namespace algorithm_exercises_csharp_test.hackerrank.warmup;
using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.lib;

[TestClass]
public class DiagonalDifferenceTest
{
  public class DiagonalDifferenceTestCase(List<List<int>> arr, int expected)
  {
    private readonly List<List<int>> arr = arr;
    private readonly int expected = expected;

    public List<List<int>> Arr
    {
      get { return arr; }
    }

    public int Expected
    {
      get { return expected; }
    }
  }

  private List<DiagonalDifferenceTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<DiagonalDifferenceTestCase>>(/*lang=json,strict*/ @"
      [
        {
          ""arr"": [
            [11, 2, 4],
            [4, 5, 6],
            [10, 8, -12]
          ],
          ""expected"": 15
        }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testDiagonalDifference()
  {
    int? result;

    foreach (DiagonalDifferenceTestCase test in testCases)
    {
      result = DiagonalDifference.diagonalDifference(test.Arr);
      Assert.AreEqual(test.Expected, result,
        string.Format(System.Globalization.CultureInfo.InvariantCulture, "DiagonalDifference.diagonalDifference answer must be: {0}", test.Expected)
      );
    }
  }
}

