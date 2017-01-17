using System;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Contracts
{
    public interface IPlayer
    {
        string Name { get; }
        int HealthPoints { get; }
        int DeffencePoints { get; }
        int AttackPoints { get; }
        RaceType Type { get; }
        ClassType ClassType { get; }

        void HandleOtherPlayerAttack(int otherPlayerAttackPoints, string otherPlayerName);
        event EventHandler<DeadPlayerEventArgs> playerDeath;
        void Equip(IItem item);
    }
}