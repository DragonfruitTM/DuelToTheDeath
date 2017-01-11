using DTTD.Engine;
using DTTD.Factory;
using DuelToTheDeath.Class;
using DuelToTheDeath.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTD
{
   public class Startup
    {
        static void Main()
        {
            GameEngine.Instance.Start();
        }
    }
}
