using DTTD.Enums;

namespace DTTD.Factory
{
    public interface IPlayer
    {
        string Name { get; set; }
        int HitPoints { get; set; }
        int DeffencePoints { get; set; }
        int AttackPoints { get; set; }
        RaceType Type { get; }
    }
}