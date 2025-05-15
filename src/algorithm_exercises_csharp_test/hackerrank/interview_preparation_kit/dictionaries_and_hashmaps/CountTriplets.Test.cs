namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class CountTripletsTest
{
  public class CountTripletsTestCase(string title, long[] input, int r, long expected)
  {
    private readonly string title = title;
    private readonly List<long> input = [.. input];
    private readonly int r = r;
    private readonly long expected = expected;

    public string Title
    {
      get { return title; }
    }

    public List<long> Input
    {
      get { return input; }
    }

    public int R
    {
      get { return r; }
    }

    public long Expected
    {
      get { return expected; }
    }
  }

  private List<CountTripletsTestCase> testCases { get; set; } = default!;
  private List<CountTripletsTestCase> bigTestCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CountTripletsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.small.testcases.json"
    ) ?? [];

    bigTestCases = JsonLoader.resourceLoad<List<CountTripletsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.big.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testCountTriplets()
  {
    long result;

    foreach (CountTripletsTestCase test in testCases)
    {
      result = CountTriplets.countTriplets(test.Input, test.R);
      Assert.AreEqual(test.Expected, result);
    }

    foreach (CountTripletsTestCase test in bigTestCases)
    {
      result = CountTriplets.countTriplets(test.Input, test.R);
      Assert.AreEqual(test.Expected, result);
    }
  }
}
