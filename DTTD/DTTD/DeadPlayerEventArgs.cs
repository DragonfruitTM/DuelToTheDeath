using System;
using DuelToTheDeath.Contracts;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath
{
    public class DeadPlayerEventArgs : EventArgs
    {
        public IPlayer playerToRemove;
        public string killerName;

        public DeadPlayerEventArgs(IPlayer playerToRemove, string killerName)
        {
            this.playerToRemove = playerToRemove;
            this.killerName = killerName;
        }
    }
}