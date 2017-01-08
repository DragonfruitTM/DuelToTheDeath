namespace DuelToTheDeath.Class
{
    using DuelToTheDeath.Interface;

    public class Rogue : IRogueSkills
    {
        public void BowAttack(int otherObjectHitPoints)
        {
            otherObjectHitPoints -= 20;
        }

        public void DeadAttack(int otherObjectHitPoints, int healthPoints)
        {
            otherObjectHitPoints -= otherObjectHitPoints / 4;
            healthPoints -= healthPoints / 10;
        }

        public void CollectHealthPointsFromCorpses(int healthPoints)
        {
            healthPoints += 10;
        }

        public void ShieldDefense(int otherObjectAttackPoints)
        {
            otherObjectAttackPoints -= otherObjectAttackPoints / 3;
        }

        public void SwordAttack(int otherObjectHitPoints)
        {
            otherObjectHitPoints -= 30;
        }

        public void DodgeAttackDefense(int healthPoints)
        {
            healthPoints -= healthPoints / 10;
        }

        public void TakeRestHealthRestoration(int healthPoints)
        {
            healthPoints += 20;
        }
    }
}