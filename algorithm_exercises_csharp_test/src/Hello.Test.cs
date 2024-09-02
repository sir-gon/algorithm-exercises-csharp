namespace algorithm_exercises_csharp;

[TestClass]
public class HelloWorldTest
{
  [TestInitialize]
  public void testInitialize()
  {
    Log.info("Hello World");
  }

  [TestMethod]
  public void testInstance()
  {
    HelloWorld a = HelloWorld.create();
    HelloWorld b = HelloWorld.create();

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
  public void testHello()
  {
    string expected = "Hello World!";
    string result = HelloWorld.hello();

    Assert.AreEqual(expected, result);
  }
}

