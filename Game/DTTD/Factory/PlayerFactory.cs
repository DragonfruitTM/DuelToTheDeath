namespace DTTD.Factory
{
    using DuelToTheDeath.Class;
    using DuelToTheDeath.Interface;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string name, ClassType playerTtype)
        {
            switch (playerTtype)
            {
                case ClassType.Mage:
                    return this.CreateMage(name);
                case ClassType.Rogue:
                    return this.CreateRogue(name);
                case ClassType.Warrior:
                    return this.CreateWarrior(name);
                default:
                    throw new NotSupportedException("No such player type exists.");
            }
        }

        public IPlayer CreateWarrior(string name)
        {
            return new Warrior(name);
        }
        public IPlayer CreateMage(string name)
        {
            return new Mage(name);
        }
        public IPlayer CreateRogue(string name)
        {
            return new Rogue(name);
        }
        public IMageSkills MageSkills()
        {
            return new Mage();
        }

        public IWarriorSkills WarriorSkills()
        {
            return new Warrior();
        }
        public IRogueSkills RogueSkills()
        {
            return new Rogue();
        }

    }
}
