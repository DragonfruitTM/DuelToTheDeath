namespace DuelToTheDeath.Class
{
    using DTTD.Abstract;
    using DTTD.Enums;
    using DTTD.Factory;
    using DTTD.Contracts;
    using Race;

    public class Rogue : Undead, IRogueSkills
    {
      /*public Rogue()  // What is the benefits of using this C'tor
            : this(null)
        {
            this.CollectHealthPointsFromCorpses();
            this.TakeRestHealthRestoration();
            this.BowAttack();
            this.DeadAttack();
            this.DodgeAttackDefense();
            this.ShieldDefense();
            this.SwordAttack();
        }*/

        public Rogue(string undeadName)
            : base(undeadName)
        {
        }

        public void BowAttack(IPlayer enemy)
        {
            enemy.HitPoints -= 20;
        }

        public void DeadAttack(IPlayer enemy)
        {
            enemy.HitPoints /=4;
            this.HitPoints /= 10;
        }

        public void CollectHealthPointsFromCorpses()
        {
            this.HitPoints += 10;
        }

        public void ShieldDefense(IPlayer enemy)
        {
            enemy.AttackPoints /= 3;
        }

        public void SwordAttack(IPlayer enemy)
        {
            enemy.HitPoints -= 50;
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