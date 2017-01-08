namespace DuelToTheDeath.Interface
{
    public interface IMageSkills
    {
        void BlackMagicAttack(int otherObjectHitPoints, int manaPoints);

        void WhiteMagicAttack(int otherObjectHitPoints, int manaPoints);

        void EnergyShieldDefense(int otherObjectAttackPoints, int manaPoints);

        void DodgeAttackDefense(int otherObjectAttackPoints, int manaPoints);

        void EatFoodHealthRestoration(int healthPoints, int manaPoints);

        void MagicHealthRestoration(int healthPoints, int manaPoints);
    }
}