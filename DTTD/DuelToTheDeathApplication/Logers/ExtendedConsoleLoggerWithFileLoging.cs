using DuelToTheDeath.Contracts;
using System;

namespace DuelToTheDeathApplication.Logers
{
    public class ExtendedConsoleLoggerWithFileLoging : ILogger
    {
        private readonly ILogger firstLogger;
        private readonly ILogger secondLogger;

        public ExtendedConsoleLoggerWithFileLoging (ILogger firstLogger, ILogger secondLogger)
        {
            if (firstLogger == null || secondLogger == null)
            {
                throw new NullReferenceException("Logger cannot be null!");
            }

            this.firstLogger = firstLogger;
            this.secondLogger = secondLogger;
        }

        public void Log(string message)
        {
            this.firstLogger.Log(message);
            this.secondLogger.Log(message);
        }
    }
}
