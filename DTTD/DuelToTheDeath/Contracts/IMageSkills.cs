using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Contracts
{
    public interface IMageSkills : IPlayer
    {
        void WhiteMagicAttack(IPlayer enemy);

        void EnergyShieldDefense();

        void DodgeSingleAttack();

        void Heal();

        void BlackMagicAttack(IPlayer enemy);

    }
}