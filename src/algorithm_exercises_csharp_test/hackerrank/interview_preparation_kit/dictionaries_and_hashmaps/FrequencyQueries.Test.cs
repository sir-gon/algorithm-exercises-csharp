namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class FrequencyQueriesTest
{
  public class FrequencyQueriesTestCase(string title, List<List<int>> input, List<int> expected)
  {
    private string title = title;
    private List<List<int>> input = input;
    private List<int> expected = expected;

    public string Title
    {
      get { return title; }
    }
    public List<List<int>> Input
    {
      get { return input; }
    }
    public List<int> Expected
    {
      get { return expected; }
    }
  }

  List<FrequencyQueriesTestCase> testCases { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCase6 { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCaseBorderCases { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCaseBorderCaseException { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcases.json"
    ) ?? [];

    testCase6 = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase6.json"
    ) ?? [];

    testCaseBorderCases = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase_border_cases.json"
    ) ?? [];

    testCaseBorderCaseException = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase_border_case_exception.json"
    ) ?? [];
  }

  [TestMethod]
  public void testFrequencyQueries()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCases)
    {
      solutionFound = FrequencyQueries.freqQuery(test.Input);
      CollectionAssert.AreEqual(
        test.Expected,
        solutionFound,
        $"FrequencyQueries.freqQuery({test.Input}) answer must be: {test.Expected}"
      );
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBigCases()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCase6)
    {
      solutionFound = FrequencyQueries.freqQuery(test.Input);
      CollectionAssert.AreEqual(
        test.Expected,
        solutionFound,
        $"FrequencyQueries.freqQuery({test.Input}) answer must be: {test.Expected}"
      );
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBorderCases()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCaseBorderCases)
    {
      solutionFound = FrequencyQueries.freqQuery(test.Input);
      CollectionAssert.AreEqual(
        test.Expected,
        solutionFound,
        $"FrequencyQueries.freqQuery({test.Input}) answer must be: {test.Expected}"
      );
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBorderCaseException()
  {
    foreach (FrequencyQueriesTestCase test in testCaseBorderCaseException)
    {
      Assert.ThrowsExactly<InvalidOperationException>(() => _ = FrequencyQueries.freqQuery(test.Input));
    }
  }
}
