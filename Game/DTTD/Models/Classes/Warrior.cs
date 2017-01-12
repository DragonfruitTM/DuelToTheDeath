namespace DuelToTheDeath.Class
{
    using DTTD.Contracts;
    using Race;
    using System.Collections.Generic;
    using DTTD.Enums;
    public class Warrior : Ork, IWarriorSkills
    {
      /*public Warrior()    // What is the benefits of using this C'tor
            : this(null)
        {
            this.SpearAttack();
            this.UseMedicineHealthRestoration();
            this.UseShieldDefense();
            this.EatRootsHealthRestoration();
            this.CutByAxeAttack();
            this.BerserkMode();
            this.BlockAttackDefense();
        }*/

        public Warrior(string orkName) : base(orkName)
        {

        }

        public void BerserkMode()
        {
            this.AttackPoints *= 2;
            this.HitPoints /= 2;
        }

        //only for one move
        public void BlockAttackDefense()
        {
            this.DeffencePoints = 100000;
        }

        public void CutByAxeAttack(IPlayer enemy)
        {
            enemy.HitPoints -= 50;
        }

        public void EatRootsHealthRestoration()
        {
            this.HitPoints += 20;
        }

        public void SpearAttack(IPlayer enemy)
        {
            enemy.HitPoints -= 30;
        }

        public void UseMedicineHealthRestoration()
        {
            this.HitPoints += 30;
        }

        public void UseShieldDefense(IPlayer enemy)
        {
            enemy.HitPoints /= 3;
        }
    }
}