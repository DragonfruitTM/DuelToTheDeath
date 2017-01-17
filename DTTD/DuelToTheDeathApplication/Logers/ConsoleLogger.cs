using System;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeathApplication.Logers
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
