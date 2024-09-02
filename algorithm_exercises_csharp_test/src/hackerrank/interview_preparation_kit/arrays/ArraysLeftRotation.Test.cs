namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class ArraysLeftRotationTest
{
  public class ArraysLeftRotationTestCase
  {
    public List<int> input = []; public List<int> expected = [];
  }

  public class ArraysLeftRotationsTestCase
  {
    public List<int> input = []; public int d; public List<int> expected = [];
  }

  private static readonly ArraysLeftRotationTestCase[] tests = [
    new() { input = [1, 2, 3, 4, 5], expected = [2, 3, 4, 5, 1] },
    new() { input = [2, 3, 4, 5, 1], expected = [3, 4, 5, 1, 2] },
    new() { input = [3, 4, 5, 1, 2], expected = [4, 5, 1, 2, 3] },
    new() { input = [4, 5, 1, 2, 3], expected = [5, 1, 2, 3, 4] },
    new() { input = [5, 1, 2, 3, 4], expected = [1, 2, 3, 4, 5] }
  ];

  private static readonly ArraysLeftRotationsTestCase[] testRotationsCases = [
    new() { input = [1, 2, 3, 4, 5], d = 4, expected = [5, 1, 2, 3, 4] }
  ];

  [TestMethod]
  public void testRotLeftOne()
  {
    List<int> result;

    foreach (ArraysLeftRotationTestCase test in tests)
    {
      result = ArraysLeftRotation.rotLeftOne(test.input);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }

  [TestMethod]
  public void testRotLeft()
  {
    List<int> result;

    foreach (ArraysLeftRotationsTestCase test in testRotationsCases)
    {
      result = ArraysLeftRotation.rotLeft(test.input, test.d);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }
}

