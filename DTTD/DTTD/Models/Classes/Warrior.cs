using DuelToTheDeath.Contracts;
using DuelToTheDeath.Race;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Class
{
    public class Warrior : Ork, IWarriorSkills
    {
        private const int DeffencePointsOnBlockAttackDefense = 1000;
        private const int AttackPointsMultiplicationOnBerserkMode = 2;
        private const int HealthPointsReductionOnBerserkMode = 2;
        private const int CutByAxeAttackPoints = 50;
        private const int HealthPointsOnEatRootsHealthRestoration = 20;
        private const int SpearAttackPoints = 30;
        private const int HealthPointsOnUseMedicineHealthRestoration = 30;
        private const int HealthPointsReductionOnUseShieldDefense = 3;


        public Warrior(string orkName) : base(orkName, ClassType.Warrior)
        {

        }

        public void BerserkMode()
        {
            this.AttackPoints *= AttackPointsMultiplicationOnBerserkMode;
            this.HealthPoints /= HealthPointsReductionOnBerserkMode;
        }

        public void BlockAttackDefense()
        {
            this.DeffencePoints = DeffencePointsOnBlockAttackDefense;
        }

        public void CutByAxeAttack(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(CutByAxeAttackPoints, this.Name);
        }

        public void EatRootsHealthRestoration()
        {
            this.HealthPoints += HealthPointsOnEatRootsHealthRestoration;
        }

        public void SpearAttack(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(SpearAttackPoints, this.Name);
        }

        public void UseMedicineHealthRestoration()
        {
            this.HealthPoints += HealthPointsOnUseMedicineHealthRestoration;
        }

        public void UseShieldDefense(IPlayer enemy)
        {
            enemy.HandleOtherPlayerAttack(enemy.HealthPoints / HealthPointsReductionOnUseShieldDefense, this.Name);
        }
    }
}
