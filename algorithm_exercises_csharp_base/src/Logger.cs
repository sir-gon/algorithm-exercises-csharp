namespace algorithm_exercises_csharp;

using Microsoft.Extensions.Logging;
using System;

public sealed class LoggerSingleton
{
  private static readonly Lazy<LoggerSingleton> _instance = new(() => new LoggerSingleton());

  public static LoggerSingleton Instance => _instance.Value;

  public ILogger Logger { get; }

  private LoggerSingleton()
  {
    // Read the LOG_LEVEL environment variable
    var logLevelEnv = Environment.GetEnvironmentVariable("LOG_LEVEL") ?? "Information";

    // Convert the environment variable value to LogLevel
    if (!Enum.TryParse<LogLevel>(logLevelEnv, ignoreCase: true, out var logLevel))
    {
      logLevel = LogLevel.Information; // Set the minimum logging level
    }

    var loggerFactory = LoggerFactory.Create(builder =>
    {
      builder
              .AddConsole()
              .SetMinimumLevel(logLevel); // set minimum logging level
    });

    Logger = loggerFactory.CreateLogger("GlobalLogger");

    Logger.LogInformation("Initializing");

    Logger.LogInformation("Info level enabled");
    Logger.LogWarning("Warning level enabled");
    Logger.LogError("Error level enabled");
    Logger.LogDebug("Debug level enabled");
  }
}

public static class Log
{
  public static ILogger getLogger()
  {
    return LoggerSingleton.Instance.Logger;
  }

  public static void info(string message, params object?[] args)
  {
#pragma warning disable CA2254 // Template should be a static expression
    LoggerSingleton.Instance.Logger.LogInformation(message, args);
#pragma warning restore CA2254 // Template should be a static expression
  }

  public static void warning(string message, params object?[] args)
  {
#pragma warning disable CA2254 // Template should be a static expression
    LoggerSingleton.Instance.Logger.LogWarning(message);
#pragma warning restore CA2254 // Template should be a static expression
  }

  public static void error(string message, params object?[] args)
  {
#pragma warning disable CA2254 // Template should be a static expression
    LoggerSingleton.Instance.Logger.LogError(message);
#pragma warning restore CA2254 // Template should be a static expression
  }

  public static void debu(string message, params object?[] args)
  {
#pragma warning disable CA2254 // Template should be a static expression
    LoggerSingleton.Instance.Logger.LogDebug(message);
#pragma warning restore CA2254 // Template should be a static expression
  }
}
