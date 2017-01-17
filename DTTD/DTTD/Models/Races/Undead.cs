using DuelToTheDeath.Abstract;
using DuelToTheDeath.Enums;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeath.Race
{
    public class Undead : Player, IPlayer
    {
        private const int InitialUndeadHealthPoints = 3000;
        private const int InitialUndeadAttackPoints = 40;
        private const int InitialUndeadDeffencePoints = 200;
        private const int InitialUndeadHpDegeneration = 50;

        public Undead(string undeadName, ClassType classType)
            : base(undeadName, InitialUndeadHealthPoints,
                 InitialUndeadAttackPoints, InitialUndeadDeffencePoints
                  ,RaceType.Undead, classType)
        {
            this.HpDegeneration = InitialUndeadHpDegeneration;
        }
    
        public int HpDegeneration { get; private set; }
    }
}
