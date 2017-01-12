using System.Collections.Generic;

namespace DTTD.Contracts
{
    interface IComand
    {
        IList<string> Parameters { get; }
    }
}
