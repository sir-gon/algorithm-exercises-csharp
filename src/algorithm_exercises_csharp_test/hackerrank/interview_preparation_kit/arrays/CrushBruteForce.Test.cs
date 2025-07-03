namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class CrushBruteForceTest
{
  public class CrushBruteForceTestCase(string title, List<List<int>> queries, int n, long expected)
  {
    public string Title { get; } = title;
    public List<List<int>> Queries { get; } = queries;
    public int N { get; } = n;
    public long Expected { get; } = expected;
  }

  private List<CrushBruteForceTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CrushBruteForceTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/crush.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testArrayManipulation()
  {
    long result;

    foreach (CrushBruteForceTestCase test in testCases)
    {
      result = CrushBruteForce.arrayManipulation(test.N, test.Queries);
      Assert.AreEqual(test.Expected, result);
    }
  }
}

