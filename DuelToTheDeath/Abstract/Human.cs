
namespace DuelToTheDeath.Race
{
    public abstract class Human
    {
        private string humanName;
        private const int InitialHumanHitPoints = 700;
        private const int InitialHumanDeffencePoints = 100;
        private const int InitialHumanManaPoints = 200;
        private const int InitialHumanManaRegeneration = 20;

        public Human(string humanName)
        {
            this.humanName = humanName;
            this.HitPoints = InitialHumanHitPoints;
            this.DeffencePoints = InitialHumanDeffencePoints;
            this.ManaPoints = InitialHumanManaPoints;
            this.ManaPoints = InitialHumanManaRegeneration;
        }

        public string HumanName
        {
            get
            {
                return this.humanName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                if (value.Substring(0, 4) != "HuMn_")
                {
                    throw new ArgumentException();
                }

                this.humanName = value;

            }
        }

        public int HitPoints { get; set; }
        public int DeffencePoints { get; set; }
        public int ManaPoints { get; set; }
        public int ManaRegeneration { get; set; }
    }
}