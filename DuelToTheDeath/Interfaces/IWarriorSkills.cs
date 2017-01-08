namespace DuelToTheDeath.Interface
{
    public interface IWarriorSkills
    {
        void CutByAxeAttack(int otherObjectHitPoints);

        void SpearAttack(int otherObjectHitPoints);

        void BerserkMode(int otherObjectHitPoints, int healthPoints);

        void UseShieldDefense(int otherObjectAttackPoints);

        void BlockAttackDefense(int otherObjectAttackPoints);

        void EatRootsHealthRestoration(int healthPoints);

        void UseMedicineHealthRestoration(int healthPoints);
    }
}
