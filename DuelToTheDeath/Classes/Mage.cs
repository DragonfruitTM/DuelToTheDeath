namespace DuelToTheDeath.Class
{
    using DuelToTheDeath.Interface;

    public class Mage : IMageSkills
    {

        public void BlackMagicAttack(int otherObjectHitPoints, int manaPoints)
        {
            otherObjectHitPoints -= 30;
            manaPoints -= 70;
        }

        public void DodgeAttackDefense(int healthPoints, int manaPoints)
        {
            manaPoints -= 100;
        }

        public void EatFoodHealthRestoration(int healthPoints, int manaPoints)
        {
            healthPoints += 20;
            manaPoints -= 30;
        }

        public void EnergyShieldDefense(int otherObjectAttackPoints, int manaPoints)
        {
            otherObjectAttackPoints -= otherObjectAttackPoints / 3;
            manaPoints -= 30;
        }

        public void MagicHealthRestoration(int healthPoints, int manaPoints)
        {
            healthPoints += 20;
            manaPoints -= 50;
        }

        public void WhiteMagicAttack(int otherObjectHitPoints, int manaPoints)
        {
            otherObjectHitPoints -= 20;
            manaPoints -= 50;
        }

    }
}