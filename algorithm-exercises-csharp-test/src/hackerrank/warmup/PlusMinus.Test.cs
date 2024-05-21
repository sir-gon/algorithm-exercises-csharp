namespace algorithm_exercises_csharp.hackerrank;

[TestClass]
public class PlusMinusTest
{
  [TestMethod]
  public void testPlusMinus()
  {
    List<int> a = [-4, 3, -9, 0, 4, 1];
    string expectedAnswer = String.Join("\n", "0.500000", "0.333333", "0.166667");
    string result = PlusMinus.plusMinus(a);

    Assert.AreEqual(expectedAnswer, result);

  }
}

