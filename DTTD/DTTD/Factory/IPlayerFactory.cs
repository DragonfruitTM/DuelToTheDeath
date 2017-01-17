using DuelToTheDeath.Contracts;

namespace DuelToTheDeath.Factory
{
    public interface IPlayerFactory
    {
        IWarriorSkills CreateWarrior(string name);
        IMageSkills CreateMage(string name);
        IRogueSkills CreateRogue(string name);
    }
}