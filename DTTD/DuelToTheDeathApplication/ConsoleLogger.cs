using System;
using DTTD.Contracts;

namespace DuelToTheDeathApplication
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(new string('-', 50));
        }
    }
}
