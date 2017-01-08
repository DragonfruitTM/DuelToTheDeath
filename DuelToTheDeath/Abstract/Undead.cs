namespace DuelToTheDeath.Race
{
    public abstract class Undead
    {
        private string undeadName;
        private const int InitialUndeadHitPoints = 2000;
        private const int InitialUndeadAttackPoints = 40;
        private const int InitialUndeadDeffencePoints = 200;
        private const int InitialUndeadHpDegeneration = 50;

        public Undead(string undeadName)
        {
            this.undeadName = undeadName;
            this.HitPoints = InitialUndeadHitPoints;
            this.AttackPoints = InitialUndeadAttackPoints;
            this.DeffencePoints = InitialUndeadDeffencePoints;
            this.HpDegeneration = InitialUndeadHpDegeneration;
        }

        public string UndeadName
        {
            get
            {
                return this.undeadName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                if (value.Substring(0, 4) != "ZomB_")
                {
                    throw new ArgumentException();
                }

                this.undeadName = value;
            }
        }

        public int HitPoints { get; set; }
        public int DeffencePoints { get; set; }
        public int HpDegeneration { get; set; }
        public int AttackPoints { get; set; }
    }
}