namespace DTTD.Factory
{
    using DTTD.Enums;
    using System.Collections;
    using System.Collections.Generic;
    public interface IPlayer
    {
        string Name { get; set; }
        int HitPoints { get; set; }
        int DeffencePoints { get; set; }
        int AttackPoints { get; set; }
        RaceType Type { get; }
        ClassType ClassType { get; set; }       
    }
}