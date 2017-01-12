using DuelToTheDeath.Class;
using DuelToTheDeath.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTD.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
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
        
        //Trqbva ni prazen constructor na Mage, koito edinstveno deistvie shte bude da mi dava da accessvam skilovete mu
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
