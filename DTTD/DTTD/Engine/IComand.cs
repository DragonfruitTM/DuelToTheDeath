using System.Collections.Generic;

namespace DuelToTheDeath.Contracts
{
   public interface IComand
    {
        IList<string> Parameters { get; }
    }
}
