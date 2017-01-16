namespace DuelToTheDeath.Race
{
    using DTTD.Factory;
    using DTTD.Abstract;
    using DTTD.Enums;
    using DTTD.Exceptions;

    public class Human : Player, IPlayer
    {
        private string humanName;
        private const int InitialHumanAttackPoints = 0;
        private const int InitialHumanHitPoints = 700;
        private const int InitialHumanDeffencePoints = 100;
        private const int InitialHumanManaPoints = 200;


        public Human(string humanName)
            : base(humanName, InitialHumanHitPoints, InitialHumanAttackPoints
                 , InitialHumanDeffencePoints, RaceType.Human)
        {
            this.Mana = InitialHumanManaPoints;
        }

        public override string Name
        {
            get
            {
                return this.humanName;
            }

            set
            {
                if (value.Substring(0, 5) != "HumN_")
                {
                    throw new InvalidPlayerNameException();
                }

                this.humanName = value;
            }
        }

        public int Mana { get; set; }
    }
}