using System.Collections.Generic;

namespace DTTD.Contracts
{
   public interface IComand
    {
        IList<string> Parameters { get; }
    }
}
