namespace DuelToTheDeath.Class
{
    using System;
    using DTTD.Contracts;
    using Race;
    using DTTD.Factory;
    using DTTD.Abstract;
    using DTTD.Enums;

    public class Mage : Human, IMageSkills
    {
      /*public Mage()   // What is the benefits of using this C'tor
            : this(null)
        {
            this.Heal();
            //only for one move
            this.DodgeSingleAttack();

            this.BlackMagicAttack();  //Why we call this methods in C'tor
            //call every move
            this.EnergyShieldDefense();

            this.WhiteMagicAttack();  //Why we call this methods in C'tor
        }*/

        public Mage(string humanName)
            : base(humanName)
        {

        }

        public void BlackMagicAttack(IPlayer enemy)
        {
            enemy.HitPoints -= 300;
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

        public void WhiteMagicAttack(IPlayer enemy)
        {
            this.Mana -= 150;
            enemy.HitPoints -= 100;
        }


    }
}