using System;
using DTTD.Contracts;

namespace DTTD.Items.Weapons
{
    public class Bow 
    {
        private int attackPoints;

        public Bow(int attackPoints)
        {
            this.AttackPoints = attackPoints;
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

    }
}
