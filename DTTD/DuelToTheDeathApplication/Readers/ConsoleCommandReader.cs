using System;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeathApplication.Readers
{
    public class ConsoleCommandReader : ICommandReader
    {
        public string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
