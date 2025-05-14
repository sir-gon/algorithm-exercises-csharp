namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class CrushOptimizedTest
{
  public class CrushOptimizedTestCase(string title, List<List<int>> queries, int n, long expected)
  {
    private string title = title;
    private List<List<int>> queries = queries;
    private int n = n;
    private long expected = expected;
    public string Title
    {
      get { return title; }
    }
    public List<List<int>> Queries
    {
      get { return queries; }
    }
    public int N
    {
      get { return n; }
    }
    public long Expected
    {
      get { return expected; }
    }
  }

  private List<CrushOptimizedTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CrushOptimizedTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/crush.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testArrayManipulation()
  {
    long result;

    foreach (CrushOptimizedTestCase test in testCases)
    {
      result = CrushOptimized.arrayManipulation(test.N, test.Queries);
      Assert.AreEqual(test.Expected, result);
    }
  }
}

