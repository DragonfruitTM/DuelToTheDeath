namespace DTTD.Factory
{
    using DTTD.Items;
    using DTTD.Items.Weapons;
    public class ItemFactory : IItemFactory
    {
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
    }
}
