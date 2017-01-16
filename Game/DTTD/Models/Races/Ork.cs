namespace DuelToTheDeath.Race
{
    using DTTD.Abstract;
    using DTTD.Enums;
    using DTTD.Exceptions;
    using DTTD.Factory;
    using System;
    public class Ork : Player, IPlayer
    {
        private string orkName;
        private const int InitialOrkHitPoints = 2000;
        private const int InitialOrkAttackPoints = 20;
        private const int InitialOrkDeffencePoints = 200;
        private const int InitialOrkHpRegeneration = 20;

        public Ork(string orkName)
            : base(orkName, InitialOrkHitPoints, InitialOrkAttackPoints
                  , InitialOrkDeffencePoints
                  , RaceType.Ork)
        {
            this.HpRegeneration = InitialOrkHpRegeneration;
        }

        public override string Name
        {
            get
            {
                return this.orkName;
            }

            set
            {
                if (value.Substring(0, 5) != "RazL_")
                {
                    throw new InvalidPlayerNameException();
                }

                this.orkName = value;
            }
        }

        public int HpRegeneration { get; set; }

    }
}