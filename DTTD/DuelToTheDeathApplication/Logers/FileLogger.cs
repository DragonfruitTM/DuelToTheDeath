using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeathApplication.Logers
{
    class FileLogger : ILogger
    {
        private const string defaultPath = "./LogFiles/Log.txt";

        private readonly string filePath;

        public FileLogger (string filePath = defaultPath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                this.filePath = defaultPath;
            }

            this.filePath = filePath;
        }

        public void Log(string message)
        {
            
        }
    }
}
