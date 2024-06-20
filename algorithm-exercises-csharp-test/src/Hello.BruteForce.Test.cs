namespace algorithm_exercises_csharp;

[TestClass]
public class HelloWorldBruteForceTest
{
  private static readonly string[] allowedValues = ["TRUE", "YES", "1"];

  [TestInitialize]
  public void testInitialize()
  {
    var envValue = Environment.GetEnvironmentVariable("BRUTEFORCE");
    envValue = envValue?.ToUpper();
    if (!allowedValues.Contains(envValue, StringComparer.OrdinalIgnoreCase))
    {
      Assert.Inconclusive($"Skipping BRUTEFORCE test because environment variable 'BRUTEFORCE' is not one of the expected values.");
    }
  }

  [TestMethod]
  public void testHelloBruteForce()
  {
    string expected = "Hello World!";
    string result = HelloWorld.hello();

    Assert.AreEqual(expected, result);
  }
}
