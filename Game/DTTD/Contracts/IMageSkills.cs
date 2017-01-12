using DTTD.Enums;

namespace DTTD.Contracts
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