namespace algorithm_exercises_csharp;

[TestClass]
public class HelloWorldTest
{
  [TestMethod]
  public void TestInstance()
  {
    HelloWorld a = HelloWorld.Create();
    HelloWorld b = HelloWorld.Create();

    Type knownType = typeof(HelloWorld);
    Type resultType = a.GetType();
    Assert.IsInstanceOfType(a, knownType);
    Assert.IsInstanceOfType(a, resultType);

    int resultHashCode = a.GetHashCode();
    Assert.IsNotNull(resultHashCode);

    bool expectedEquals = true;
    bool expectedNotEquals = false;
    Assert.AreEqual(expectedEquals, a.Equals(a));
    Assert.AreEqual(expectedNotEquals, a.Equals(b));

    string expectedString = "algorithm_exercises_csharp.HelloWorld";
    string? resultString = a.ToString();
    Assert.AreEqual<string>(expectedString, resultString);
  }

  [TestMethod]
  public void TestHello()
  {
    string expected = "Hello World!";
    string result = HelloWorld.Hello();

    Assert.AreEqual(expected, result);

  }
}

