using DuelToTheDeath.Contracts;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Models.Items
{
    public struct Item : IItem
    {
        private const int InitialAxeAttackPoints = 50;
        private const int InitialAxeDefensePoints = 0;
        private const int InitialBowAttackPoints = 30;
        private const int InitialBowDefensePoints = 0;
        private const int InitialHammerAttackPoints = 20;
        private const int InitialHammerDefensePoints = 0;
        private const int InitialKnifeAttackPoints = 15;
        private const int InitialKnifeDefensePoints = 0;
        private const int InitialSwordAttackPoints = 60;
        private const int InitialSwordDefensePoints = 0;
        private const int InitialArmorAttackPoints = 0;
        private const int InitialArmorDefensePoints = 100;
        private const int InitialDefaultAttackPoints = 0;
        private const int InitialDefaultDefensePoints = 100;

        private int attackPoints;
        private int defensePoints;

        public Item(ItemType type)
        {
            this.Type = type;

            switch (type)
            {
                case ItemType.Axe:
                    this.attackPoints = InitialAxeAttackPoints;
                    this.defensePoints = InitialAxeDefensePoints;
                    break;
                case ItemType.Bow:
                    this.attackPoints = InitialBowAttackPoints;
                    this.defensePoints = InitialBowDefensePoints;
                    break;
                case ItemType.Hammer:
                    this.attackPoints = InitialHammerAttackPoints;
                    this.defensePoints = InitialHammerDefensePoints;
                    break;
                case ItemType.Knife:
                    this.attackPoints = InitialKnifeAttackPoints;
                    this.defensePoints = InitialKnifeDefensePoints;
                    break;
                case ItemType.Sword:
                    this.attackPoints = InitialSwordAttackPoints;
                    this.defensePoints = InitialSwordDefensePoints;
                    break;
                case ItemType.Armor:
                    this.attackPoints = InitialArmorAttackPoints;
                    this.defensePoints = InitialArmorDefensePoints;
                    break;
                default:
                    this.attackPoints = InitialDefaultAttackPoints;
                    this.defensePoints = InitialDefaultDefensePoints;
                    break;
            }
        }

        public ItemType Type { get; private set; }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
        }
    }
}
