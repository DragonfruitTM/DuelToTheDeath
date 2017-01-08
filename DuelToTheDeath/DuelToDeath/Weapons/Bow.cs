using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelToDeath.Weapons
{
    public class Bow
    {
        private int attackPoints;

        public Bow(int attackPoints)
        {
            this.attackPoints = attackPoints;
        }
    }

    public int AttackPoints
    {
        get
        {
            return this.attackPoints;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("AttackPoints can not be negative!");
            }

            this.attackPoints = value;
        }
    }

    public IUnit Owner
    {
        get
        {
            return this.owner;
        }

        set
        {
            if (value == null)
            {
                throw new NullReferenceException("Owner can not be null!");
            }

            this.Owner = value;
        }
    }
}
