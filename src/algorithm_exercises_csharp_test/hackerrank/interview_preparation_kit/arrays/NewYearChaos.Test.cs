namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class NewYearChaosTest
{
  public class NewYearChaosTestCase(string title, int[] input, string expected)
  {
    private readonly string title = title;
    private readonly List<int> input = [.. input];
    private readonly string expected = expected;

    public string Title
    {
      get { return title; }
    }

    public List<int> Input
    {
      get { return input; }
    }

    public string Expected
    {
      get { return expected; }
    }
  }

  private List<NewYearChaosTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<NewYearChaosTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/new_year_chaos.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testMinimumBribesText()
  {
    string result;

    foreach (NewYearChaosTestCase test in testCases)
    {
      result = NewYearChaos.minimumBribesText(test.Input);
      NewYearChaos.minimumBribes(test.Input);

      Assert.AreEqual(test.Expected, result);
    }
  }
}

