using System;

namespace DTTD.Items
{
    public class Armor
    {
        private int defencePoints;

        public Armor(int defencePoints)
        {
            this.DefencePoints = defencePoints;
        }

        public int DefencePoints
        {
            get
            {
                return this.defencePoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("AttackPoints can not be negative!");
                }

                this.defencePoints = value;
            }
        }
    }
}
