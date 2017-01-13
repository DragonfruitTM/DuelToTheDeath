namespace DTTD.Contracts
{
    public interface IWarriorSkills : IPlayer
    {
        void CutByAxeAttack(IPlayer enemy);

        void SpearAttack(IPlayer enemy);

        void BerserkMode();

        void UseShieldDefense(IPlayer enemy);

        void BlockAttackDefense();

        void EatRootsHealthRestoration();

        void UseMedicineHealthRestoration();
    }
}
