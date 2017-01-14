using System;
using DTTD.Contracts;

namespace DuelToTheDeathApplication
{
    public class ConsoleCommandReader : ICommandReader
    {
        public string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
