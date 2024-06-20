namespace algorithm_exercises_csharp;

using Microsoft.Extensions.Logging;
using System;

public sealed class LoggerSingleton
{
  private static readonly Lazy<LoggerSingleton> _instance = new Lazy<LoggerSingleton>(() => new LoggerSingleton());

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
              .SetMinimumLevel(logLevel); // Configura el nivel mínimo de logging
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

  public static void info(string message)
  {
    LoggerSingleton.Instance.Logger.LogInformation(message);
  }

  public static void warning(string message)
  {
    LoggerSingleton.Instance.Logger.LogWarning(message);
  }

  public static void error(string message)
  {
    LoggerSingleton.Instance.Logger.LogError(message);
  }

  public static void debug(string message)
  {
    LoggerSingleton.Instance.Logger.LogDebug(message);
  }
}
