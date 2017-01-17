using DuelToTheDeath.Contracts;
using DuelToTheDeath.Abstract;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Race
{
    public class Human : Player,IPlayer
    {
        private const int InitialHumanAttackPoints = 0;
        private const int InitialHumanHealthPoints = 700;
        private const int InitialHumanDeffencePoints = 100;
        private const int InitialHumanManaPoints = 200;


        public Human(string humanName, ClassType classType)
            :base(humanName,InitialHumanHealthPoints,InitialHumanAttackPoints
                 ,InitialHumanDeffencePoints,RaceType.Human, classType)
        {
            this.Mana = InitialHumanManaPoints;         
        }      

        public int Mana { get; protected set; }
    }
}
