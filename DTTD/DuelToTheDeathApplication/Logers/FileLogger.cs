using DuelToTheDeath.Contracts;
using System.IO;

namespace DuelToTheDeathApplication.Logers
{
    public class FileLogger : ILogger
    {
        private const string defaultPath = "log.txt";
        private readonly string filePath;
        private const bool AppendToFile = true;

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
            using (StreamWriter streamWriter = new StreamWriter(this.filePath, AppendToFile))
            {
                streamWriter.AutoFlush = true;
                streamWriter.WriteLine(message);
            }
        }
    }
}
