namespace DTTD.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DTTD.Contracts;

    public class Command : IComand
    {
        private const char SplitCommandSymbol = ' ';
        private IList<string> parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }
        private void TranslateInput(string input)
        {
            var com = input.Split(SplitCommandSymbol);
           
            foreach (var line in com)
            {
                this.Parameters.Add(line);
            }


        }
    }
}
