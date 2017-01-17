using DuelToTheDeath.Contracts;
using DuelToTheDeath.Race;
using DuelToTheDeath.Exceptions;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Class
{
    public class Mage : Human, IMageSkills
    {
        private const int WhiteMagicAttackPoints = 100;
        private const int ManaPointsConsumptionOnWhiteMagicAttack = 150;
        private const int BlackMagicAttackPoints = 300;
        private const int ManaPointsConsumptionOnBlackMagicAttack = 100;
        private const int DeffencePointsOnDodgeSingleAttack = 500;
        private const int ManaPointsConsumptionOnDodgeSingleAttack = 100;
        private const int HealthPointsOnHeal = 100;
        private const int ManaPointsConsumptionOnHeal = 30;
        private const int DeffencePointsMultiplicationOnEnergyShieldDefense = 3;
        private const int ManaPointsConsumptionOnEnergyShieldDefense = 50;

        public Mage(string humanName)
            : base(humanName, ClassType.Mage)
        {
        }

        public void BlackMagicAttack(IPlayer enemy)
        {
            if (this.Mana < ManaPointsConsumptionOnBlackMagicAttack)
            {
                throw new InadequateManaPointsException(this.Name);
            }

            enemy.HandleOtherPlayerAttack(BlackMagicAttackPoints, this.Name);
            this.Mana -= ManaPointsConsumptionOnBlackMagicAttack;
        }

        public void DodgeSingleAttack()
        {
            if (this.Mana < ManaPointsConsumptionOnDodgeSingleAttack)
            {
                throw new InadequateManaPointsException(this.Name);
            }

            this.DeffencePoints = DeffencePointsOnDodgeSingleAttack;
            this.Mana -= ManaPointsConsumptionOnDodgeSingleAttack;
        }

        public void Heal()
        {
            this.HealthPoints += HealthPointsOnHeal;
            this.Mana -= ManaPointsConsumptionOnHeal;

        }

        public void EnergyShieldDefense()
        {
            this.DeffencePoints *= DeffencePointsMultiplicationOnEnergyShieldDefense;
            this.Mana -= ManaPointsConsumptionOnEnergyShieldDefense;
        }

        public void WhiteMagicAttack(IPlayer enemy)
        {
            if (this.Mana < ManaPointsConsumptionOnWhiteMagicAttack)
            {
                throw new InadequateManaPointsException(this.Name);
            }

            enemy.HandleOtherPlayerAttack(WhiteMagicAttackPoints, this.Name);
            this.Mana -= ManaPointsConsumptionOnWhiteMagicAttack;
        }
    }
}