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
    class Program
    {
        static void Main(string[] args)
        {
            var eng = new GameEngine();
            eng.Start();
        }
    }
}
