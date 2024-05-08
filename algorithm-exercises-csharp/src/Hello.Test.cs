namespace algorithm_exercises_csharp;

[TestClass]
public class HelloWorldTest
{
  [TestMethod]
  public void TestHello()
  {
    string expected = "Hello World!";
    string result = HelloWorld.Hello();

    Assert.AreEqual(expected, result);

  }
}

