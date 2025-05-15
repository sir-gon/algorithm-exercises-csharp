namespace algorithm_exercises_csharp;

using Microsoft.Extensions.Logging;
using System;

public static class Log
{
  sealed class LoggerSingleton
  {
    private static readonly Lazy<LoggerSingleton> _instance = new(() => new LoggerSingleton());

    public static LoggerSingleton Instance => _instance.Value;

    public ILogger Logger { get; }
    private readonly ILoggerFactory _loggerFactory;

    private LoggerSingleton()
    {
      // Read the LOG_LEVEL environment variable
      var logLevelEnv = Environment.GetEnvironmentVariable("LOG_LEVEL") ?? "Information";

      // Convert the environment variable value to LogLevel
      if (!Enum.TryParse<LogLevel>(logLevelEnv, ignoreCase: true, out var logLevel))
      {
        logLevel = LogLevel.Information; // Set the minimum logging level
      }

      _loggerFactory = LoggerFactory.Create(builder =>
      {
        builder
                .AddConsole()
                .SetMinimumLevel(logLevel); // set minimum logging level
      });

      Logger = _loggerFactory.CreateLogger("GlobalLogger");

      _logInfo(Logger, "Initializing", Array.Empty<object>(), null);
      _logInfo(Logger, "Info level enabled", Array.Empty<object>(), null);
      _logWarning(Logger, "Warning level enabled", Array.Empty<object>(), null);
      _logError(Logger, "Error level enabled", Array.Empty<object>(), null);
      _logDebug(Logger, "Debug level enabled", Array.Empty<object>(), null);
    }
  }

  public static ILogger Logger => LoggerSingleton.Instance.Logger;

  private static readonly Action<ILogger, string, object?[]?, Exception?> _logInfo =
      LoggerMessage.Define<string, object?[]?>(
          LogLevel.Information,
          new EventId(3, nameof(info)),
          "{Message} {Args}");

  public static void info(string message, params object?[] args)
  {
    _logInfo(LoggerSingleton.Instance.Logger, message, args, null);
  }

  private static readonly Action<ILogger, string, object?[]?, Exception?> _logWarning =
      LoggerMessage.Define<string, object?[]?>(
          LogLevel.Warning,
          new EventId(2, nameof(warning)),
          "{Message} {Args}");

  public static void warning(string message, params object?[] args)
  {
    _logWarning(LoggerSingleton.Instance.Logger, message, args, null);
  }

  private static readonly Action<ILogger, string, object?[]?, Exception?> _logError =
      LoggerMessage.Define<string, object?[]?>(
          LogLevel.Error,
          new EventId(1, nameof(error)),
          "{Message} {Args}");

  public static void error(string message, params object?[] args)
  {
    _logError(LoggerSingleton.Instance.Logger, message, args, null);
  }

  private static readonly Action<ILogger, string, object?[]?, Exception?> _logDebug =
      LoggerMessage.Define<string, object?[]?>(
          LogLevel.Debug,
          new EventId(0, nameof(debug)),
          "{Message} {Args}");

  public static void debug(string message, params object?[] args)
  {
    _logDebug(LoggerSingleton.Instance.Logger, message, args, null);
  }
}
