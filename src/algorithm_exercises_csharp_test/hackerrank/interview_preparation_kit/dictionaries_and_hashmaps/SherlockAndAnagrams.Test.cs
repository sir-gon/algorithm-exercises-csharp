namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class SherlockAndAnagramsTest
{
  public class SherlockAndAnagramsTestCase
  {
    /**
     * SherlockAndAnagramsTestCase.TestCase.
     */
    public class TestCase
    {
      public string input { get; set; } = default!;
      public int expected { get; set; } = default!;
    }

    public string title { get; set; } = default!;
    public List<TestCase> tests { get; set; } = default!;
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
      foreach (SherlockAndAnagramsTestCase.TestCase test in testSet.tests)
      {
        result = SherlockAndAnagrams.sherlockAndAnagrams(test.input);
        Assert.AreEqual(test.expected, result);
      }
    }
  }
}
