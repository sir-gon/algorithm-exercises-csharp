namespace algorithm_exercises_csharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SimpleArraySumTest
{
  public class SimpleArraySumTestCase
  {
    public int[] inputs = [];
    public int expected = 0;
  }

  // dotnet_style_readonly_field = true
  private static readonly SimpleArraySumTestCase[] tests = [
    new() { inputs = [1, 2, 3, 4, 10, 11], expected = 31 }
  ];

  [TestMethod]
  public void testSimpleArraySum()
  {
    int? result;

    foreach (SimpleArraySumTestCase test in tests)
    {
      result = SimpleArraySum.simpleArraySum(test.inputs);
      Assert.AreEqual(test.expected, result);
    }
  }
}

