using DTTD.Engine;
using DTTD.Contracts;

namespace DuelToTheDeathApplication
{
    public class Startup
    {
        static void Main()
        {
            ConsoleCommandReader reader = new ConsoleCommandReader();
            ConsoleLogger logger = new ConsoleLogger();
            GameEngine.Initialise(reader, logger).Start();
        }
    }
}
