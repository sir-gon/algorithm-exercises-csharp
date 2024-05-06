namespace algorithm_exercises_csharp;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
    string expected = "Hello World!";
    string result = HelloWorld.Hello();

    Assert.AreEqual(expected, result);

  }
}

