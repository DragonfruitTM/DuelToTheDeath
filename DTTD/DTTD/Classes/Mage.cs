namespace DuelToTheDeath.Class
{
    using System;
    using DuelToTheDeath.Interface;
    using Race;
    using DTTD.Factory;
    using DTTD.Abstract;

    public class Mage : Human, IMageSkills
    {
        public Mage()
            : this(null)
        {
            this.Heal();
            //only for one move
            this.DodgeSingleAttack();
            this.BlackMagicAttack();
            //call every move
            this.EnergyShieldDefense();
            this.WhiteMagicAttack();
        }

        public Mage(string humanName)
            : base(humanName)
        {

        }

        public void BlackMagicAttack()
        {
            this.Target.HitPoints -= 300;
            this.Mana -= 150;
        }
        //only for one move
        public void DodgeSingleAttack()
        {
            this.Mana -= 100;
            this.DeffencePoints = 1000000000;
        }

        public void Heal()
        {
            this.HitPoints += 100;
            this.Mana -= 30;

        }

        //call every move
        public void EnergyShieldDefense()
        {
            this.Mana -= 50;
            this.DeffencePoints *= 3;
        }

        public void WhiteMagicAttack()
        {
            this.Mana -= 150;
            this.Target.HitPoints -= 100;
        }


    }
}