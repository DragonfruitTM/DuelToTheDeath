namespace DTTD.Factory
{
    using DuelToTheDeath.Class;
    using DTTD.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
