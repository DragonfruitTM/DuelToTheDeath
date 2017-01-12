namespace DuelToTheDeath.Race
{
    using DTTD.Abstract;
    using DTTD.Enums;
    using DTTD.Factory;
    using System;
    public class Undead : Player, IPlayer
    {
        private string undeadName;
        private const int InitialUndeadHitPoints = 3000;
        private const int InitialUndeadAttackPoints = 40;
        private const int InitialUndeadDeffencePoints = 200;
        private const int InitialUndeadHpDegeneration = 50;

        public Undead(string undeadName)
            : base(undeadName, InitialUndeadHitPoints,
                 InitialUndeadAttackPoints, InitialUndeadDeffencePoints
                  ,RaceType.Undead)
        {
            this.undeadName = undeadName;
            this.HpDegeneration = InitialUndeadHpDegeneration;
        }
    
        public int HpDegeneration { get; set; }
    }
}