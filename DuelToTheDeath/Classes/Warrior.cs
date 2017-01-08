namespace DuelToTheDeath.Class
{
    using DuelToTheDeath.Interface;

    public class Warrior : IWarriorSkills
    {
        public void BerserkMode(int otherObjectHitPoints, int healthPoints)
        {
            otherObjectHitPoints -= otherObjectHitPoints / 3;
            healthPoints -= healthPoints / 4;
        }

        public void BlockAttackDefense(int healthPoints)
        {
            healthPoints -= healthPoints / 10;
        }

        public void CutByAxeAttack(int otherObjectHitPoints)
        {
            otherObjectHitPoints -= 50;
        }

        public void EatRootsHealthRestoration(int healthPoints)
        {
            healthPoints += 20;
        }

        public void SpearAttack(int otherObjectHitPoints)
        {
            otherObjectHitPoints -= 30;
        }

        public void UseMedicineHealthRestoration(int healthPoints)
        {
            healthPoints += 50;
        }

        public void UseShieldDefense(int otherObjectAttackPoints)
        {
            otherObjectAttackPoints -= otherObjectAttackPoints / 3;
        }
    }
}