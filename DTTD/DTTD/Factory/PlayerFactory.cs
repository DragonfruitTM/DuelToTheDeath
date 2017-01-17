using DuelToTheDeath.Class;
using DuelToTheDeath.Contracts;

namespace DuelToTheDeath.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        public IWarriorSkills CreateWarrior(string name)
        {
            return new Warrior(name);
        }
        public IMageSkills CreateMage(string name)
        {
            return new Mage(name);
        }
        public IRogueSkills CreateRogue(string name)
        {
            return new Rogue(name);
        }
    }
}
