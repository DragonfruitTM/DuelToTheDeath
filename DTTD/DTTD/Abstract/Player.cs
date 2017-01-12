
namespace DTTD.Abstract
{
    using DTTD.Factory;
    using DuelToTheDeath.Class;
    using Enums;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class Player : IPlayer
    {
        private string name;

        public Player(string name, int hp, int attack, int deffence, RaceType type)
        {
            this.Name = name;
            this.HitPoints = hp;
            this.DeffencePoints = deffence;
            this.AttackPoints = attack;
        }

        public RaceType Type { get; set; }

        public IPlayer Target { get; set; }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                if (this.Type == RaceType.Human)
                {
                    if (value.Substring(0, 5) != "HumN_")
                    {
                        throw new ArgumentException("Name is invalid for the humans!!! TRAITOR!!!");
                    }
                }
                else if (this.Type == RaceType.Ork)
                {
                    if (value.Substring(0, 5) != "RazL_")
                    {
                        throw new ArgumentException("Name is invalid for the orks!!! TRAITOR!!!");
                    }
                }
                else if (this.Type == RaceType.Undead)
                {
                    if (value.Substring(0, 5) != "ZomB_")
                    {
                        throw new ArgumentException("Name is invalid for the undeads!!! TRAITOR!!!");
                    }
                }

                this.name = value;

            }
        }

        public int HitPoints { get; set; }
        public int DeffencePoints { get; set; }
        public int AttackPoints { get; set; }

        public ClassType ClassType
        {
            get;
            set;
        }
    }
}
