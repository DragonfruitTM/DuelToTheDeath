using System;

namespace DTTD.Units
{
    public class Armor
    {
        private int defencePoints;
        private IUnit owner;

        public Armor(int defencePoints)
        {
            this.DefencePoints = defencePoints;
            this.Owner = owner;
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
}
