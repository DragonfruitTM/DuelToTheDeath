using DTTD.Items;
using DTTD.Items.Weapons;

namespace DTTD.Factory
{
    interface IItemFactory
    {
        Axe EquipAxe(int atk);
        Bow EquipBow(int atk);
        Hammer EquipHammer(int atk);
        Knife EquipKnife(int atk);
        Sword EquipSword(int atk);
        Armor EquipArmor(int deff);
    }
}
