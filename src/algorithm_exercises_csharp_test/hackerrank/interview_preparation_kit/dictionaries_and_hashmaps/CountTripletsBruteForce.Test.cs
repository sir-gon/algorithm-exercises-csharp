namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class CountTripletsBruteForceTest
{
  public class CountTripletsBruteForceTestCase(string title, long[] input, int r, long expected)
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

  private List<CountTripletsBruteForceTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CountTripletsBruteForceTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.small.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testCountTriplets()
  {
    long result;

    foreach (CountTripletsBruteForceTestCase test in testCases)
    {
      result = CountTripletsBruteForce.countTriplets(test.Input, test.R);
      Assert.AreEqual(test.Expected, result);
    }
  }
}
