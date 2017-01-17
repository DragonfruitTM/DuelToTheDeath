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
            ILogger logger = new ConsoleLogger();
            GameEngine.Initialise(reader, logger).Start();
        }
    }
}
