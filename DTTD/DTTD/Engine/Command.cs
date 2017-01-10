using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTD.Engine
{
   public class Command
    {
        private const char SplitCommandSymbol = ' ';
        private List<string> parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
        }

        public List<string> Parameters
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
            var com = input.Split(SplitCommandSymbol).ToArray();
           
            foreach (var line in com)
            {
                Parameters.Add(line);
            }


        }
    }
}
