namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class CrushBruteForceTest
{
  public class CrushBruteForceTestCase
  {
    public string title { get; set; } = default!;
    public List<List<int>> queries { get; } = default!;
    public int n { get; set; } = default!;
    public long expected { get; set; } = default!;
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
      result = CrushBruteForce.arrayManipulation(test.n, test.queries);
      Assert.AreEqual(test.expected, result);
    }
  }
}

