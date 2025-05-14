namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class ArraysLeftRotationTest
{
  public class ArraysLeftRotationsTestCase(int[] input, int d, int[] expected)
  {
    private readonly List<int> input = [.. input];
    private readonly int d = d;
    private readonly List<int> expected = [.. expected];

    public List<int> Input
    {
      get { return input; }
    }
    public int D
    {
      get { return d; }
    }
    public List<int> Expected
    {
      get { return expected; }
    }
  }

  private List<ArraysLeftRotationsTestCase> testCases = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<ArraysLeftRotationsTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/ctci_array_left_rotation.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testRotLeft()
  {
    List<int> result;

    foreach (ArraysLeftRotationsTestCase test in testCases)
    {
      result = ArraysLeftRotation.rotLeft(test.Input, test.D);
      CollectionAssert.AreEquivalent(test.Expected, result);
    }
  }
}

