namespace DTTD.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreateWarrior(string name);
        IPlayer CreateMage(string name);
        IPlayer CreateRogue(string name);
        Axe EquipAxe(int atk);
        Bow EquipBow(int atk);
        Hammer EquipHammer(int atk);
        Knife EquipKnife(int atk);
        Sword EquipSword(int atk);
    }
}