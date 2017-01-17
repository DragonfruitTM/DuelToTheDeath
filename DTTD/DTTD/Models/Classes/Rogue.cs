using DuelToTheDeath.Contracts;
using DuelToTheDeath.Race;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Class
{
    public class Rogue : Undead, IRogueSkills
    {
        private const int BowAttackPoints = 20;
        private const int DeadAttackPointsReduction = 4;
        private const int PointsReductionOnDeadAttack = 10;
        private const int HealthPointsCollectedFromCorpses = 10;
        private const int ShieldDefensePointsReduction = 3;
        private const int SwordAttackPoints = 50;
        private const int DeffencePointsOnDodgeAttackDefense = 700;
        private const int TakeRestHealthRestorationPoints = 30;

        public Rogue(string undeadName)
            : base(undeadName, ClassType.Rogue)
        {
        }

        public void BowAttack(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(BowAttackPoints, this.Name);
        }

        public void DeadAttack(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(enemy.AttackPoints / DeadAttackPointsReduction, this.Name);
            this.HealthPoints /= PointsReductionOnDeadAttack;
        }

        public void CollectHealthPointsFromCorpses()
        {
            this.HealthPoints += HealthPointsCollectedFromCorpses;
        }

        public void ShieldDefense(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(enemy.AttackPoints / ShieldDefensePointsReduction, this.Name);
        }

        public void SwordAttack(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(SwordAttackPoints, this.Name);

        }

        public void DodgeAttackDefense()
        {
            this.DeffencePoints = DeffencePointsOnDodgeAttackDefense;
        }

        public void TakeRestHealthRestoration()
        {
            this.HealthPoints += TakeRestHealthRestorationPoints;
        }
    }
}
