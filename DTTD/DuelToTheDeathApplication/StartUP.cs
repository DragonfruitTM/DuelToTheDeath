using DuelToTheDeath.Engine;
using DuelToTheDeath.Contracts;
using DuelToTheDeathApplication.Logers;
using DuelToTheDeathApplication.Readers;

namespace DuelToTheDeathApplication
{
    public class Startup
    {
        static void Main()
        {
            ICommandReader reader = new ConsoleCommandReader();
            ILogger consoleLogger = new ConsoleLogger();
            ILogger fileLogger = new FileLogger();
            ILogger logger = new ExtendedConsoleLoggerWithFileLoging(consoleLogger, fileLogger);
            GameEngine.Initialise(reader, logger).Start();
        }
    }
}
