using DuelToTheDeath.Abstract;
using DuelToTheDeath.Enums;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeath.Race
{
    public class Ork : Player, IPlayer
    {
        private const int InitialOrkHealthPoints = 2000;
        private const int InitialOrkAttackPoints = 20;
        private const int InitialOrkDeffencePoints = 200;
        private const int InitialOrkHpRegeneration = 20;

        public Ork(string orkName, ClassType classType)
            : base(orkName, InitialOrkHealthPoints, InitialOrkAttackPoints
                  , InitialOrkDeffencePoints
                  , RaceType.Ork, classType)
        {
            this.HpRegeneration = InitialOrkHpRegeneration;
        }

        public int HpRegeneration { get; private set; }

    }
}
