namespace DTTD.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreateWarrior(string name);
        IPlayer CreateMage(string name);
        IPlayer CreateRogue(string name);
    }
}