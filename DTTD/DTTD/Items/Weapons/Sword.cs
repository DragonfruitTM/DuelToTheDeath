using System;
using DTTD.Contracts;

namespace DTTD.Items.Weapons
{
    public class Sword : IItem
    {
        private int attackPoints;
        private string owner;

        public Sword(int attackPoints)
        {
            this.AttackPoints = attackPoints;
            this.Owner = owner;
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

        public string Owner
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

                this.owner = value;
            }
        }
    }
}
