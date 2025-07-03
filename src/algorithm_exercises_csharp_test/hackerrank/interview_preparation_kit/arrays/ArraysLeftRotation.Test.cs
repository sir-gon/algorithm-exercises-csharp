namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class ArraysLeftRotationTest
{
  public class ArraysLeftRotationsTestCase(List<int> input, int d_rotations, List<int> expected)
  {
    public List<int> Input { get; } = input;
    public int D_rotations { get; } = d_rotations;
    public List<int> Expected { get; } = expected;
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
      result = ArraysLeftRotation.rotLeft(test.Input, test.D_rotations);
      CollectionAssert.AreEquivalent(test.Expected, result);
    }
  }
}

