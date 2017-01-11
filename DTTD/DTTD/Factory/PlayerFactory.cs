using DTTD.Units;
using DTTD.Units.Weapons;
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
        //
        public Axe EquipAxe(int atk)
        {
            return new Axe(atk);
        }
        public Bow EquipBow(int atk)
        {
            return new Bow(atk);
        }
        public Hammer EquipHammer(int atk)
        {
            return new Hammer(atk);
        }
        public Knife EquipKnife(int atk)
        {
            return new Knife(atk);
        }
        public Sword EquipSword(int atk)
        {
            return new Sword(atk);
        }
        public Armor EquipArmor(int deff)
        {
            return new Armor(deff);
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
