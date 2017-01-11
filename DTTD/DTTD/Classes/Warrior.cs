namespace DuelToTheDeath.Class
{
    using DuelToTheDeath.Interface;
    using Race;
    using System.Collections.Generic;
    using DTTD.Enums;

    public class Warrior : Ork, IWarriorSkills
    {
        public Warrior()
            : this(null)
        {
            this.SpearAttack();
            this.UseMedicineHealthRestoration();
            this.UseShieldDefense();
            this.EatRootsHealthRestoration();
            this.CutByAxeAttack();
            this.BerserkMode();
            this.BlockAttackDefense();
        }

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

        public void CutByAxeAttack()
        {
            this.Target.HitPoints -= 50;
        }

        public void EatRootsHealthRestoration()
        {
            this.HitPoints += 20;
        }

        public void SpearAttack()
        {
            this.Target.HitPoints -= 30;
        }

        public void UseMedicineHealthRestoration()
        {
            this.HitPoints += 30;
        }

        public void UseShieldDefense()
        {
            this.Target.HitPoints /= 3;
        }
    }
}