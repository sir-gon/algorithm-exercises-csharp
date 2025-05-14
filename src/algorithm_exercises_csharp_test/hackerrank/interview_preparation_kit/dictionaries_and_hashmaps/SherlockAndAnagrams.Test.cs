namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class SherlockAndAnagramsTest
{
  public class TestCase
  {
    public string input { get; set; } = default!;
    public int expected { get; set; } = default!;
  }

  public class SherlockAndAnagramsTestCase(string title, List<TestCase> tests)
  {
    private string title = title;
    private List<TestCase> tests = tests;

    public string Title
    {
      get { return title; }
    }
    public List<TestCase> Tests
    {
      get { return tests; }
    }
  }

  private List<SherlockAndAnagramsTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<SherlockAndAnagramsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/sherlock_and_anagrams.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testSherlockAndAnagrams()
  {
    int result;

    foreach (SherlockAndAnagramsTestCase testSet in testCases)
    {
      foreach (SherlockAndAnagramsTest.TestCase test in testSet.Tests)
      {
        result = SherlockAndAnagrams.sherlockAndAnagrams(test.input);
        Assert.AreEqual(test.expected, result);
      }
    }
  }
}
