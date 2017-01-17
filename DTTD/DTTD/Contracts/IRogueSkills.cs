namespace DuelToTheDeath.Contracts
{
    public interface IRogueSkills : IPlayer
    {
        void BowAttack(IPlayer enemy);

        void SwordAttack(IPlayer enemy);

        void DeadAttack(IPlayer enemy);

        void ShieldDefense(IPlayer enemy);

        void DodgeAttackDefense();

        void CollectHealthPointsFromCorpses();

        void TakeRestHealthRestoration();
    }
}
