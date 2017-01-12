namespace DuelToTheDeath.Class
{
    using DTTD.Abstract;
    using DTTD.Enums;
    using DTTD.Factory;
    using DuelToTheDeath.Interface;
    using Race;

    public class Rogue : Undead, IRogueSkills
    {
        public Rogue()
            : this(null)
        {
            this.CollectHealthPointsFromCorpses();
            this.TakeRestHealthRestoration();
            this.BowAttack();
            this.DeadAttack();
            this.DodgeAttackDefense();
            this.ShieldDefense();
            this.SwordAttack();
        }

        public Rogue(string undeadName)
            : base(undeadName)
        {
        }

        public void BowAttack()
        {
            this.Target.HitPoints -= 20;
        }

        public void DeadAttack()
        {
            this.Target.HitPoints /=4;
            this.HitPoints /= 10;
        }

        public void CollectHealthPointsFromCorpses()
        {
            this.HitPoints += 10;
        }

        public void ShieldDefense()
        {
            this.Target.AttackPoints /= 3;
        }

        public void SwordAttack()
        {
            this.Target.HitPoints -= 50;
        }

        //only for one move
        public void DodgeAttackDefense()
        {
            this.DeffencePoints = 10000000;
        }

        public void TakeRestHealthRestoration()
        {
            this.HitPoints += 20;
        }
    }
}