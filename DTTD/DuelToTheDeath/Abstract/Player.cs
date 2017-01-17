using System;
using System.Collections.Generic;
using DuelToTheDeath.Contracts;
using DuelToTheDeath.Enums;

namespace DuelToTheDeath.Abstract
{
    public abstract class Player : IPlayer
    {
        private string name;
        private ICollection<IItem> items;

        public event EventHandler<DeadPlayerEventArgs> playerDeath;

        public Player(string name, int hp, int attack, int deffence, RaceType type, ClassType classType)
        {
            this.Name = name;
            this.HealthPoints = hp;
            this.DeffencePoints = deffence;
            this.AttackPoints = attack;
            this.items = new List<IItem>();
            this.ClassType = classType;
        }

        public RaceType Type { get; protected set; }

        public IPlayer Target { get; protected set; }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Player cannot be null!");
                }

                this.name = value;

            }
        }

        public int HealthPoints { get; protected set; }
        public int DeffencePoints { get; protected set; }
        public int AttackPoints { get; protected set; }
        public ClassType ClassType { get; protected set; }

        public void HandleOtherPlayerAttack(int otherPlayerAttackPoints, string otherPlayerName)
        {
            this.DeffencePoints -= otherPlayerAttackPoints;

            if (this.DeffencePoints < 0)
            {
                this.HealthPoints += this.DeffencePoints;
                this.DeffencePoints = 0;
            }

            if (this.HealthPoints <= 0)
            {
                DeadPlayerEventArgs args = new DeadPlayerEventArgs(this, otherPlayerName);
                this.playerDeath(this, args);
            }
        }

        public void Equip(IItem item)
        {
            this.items.Add(item);
            this.AttackPoints += item.AttackPoints;
            this.DeffencePoints += item.DefensePoints;
        }
    }
}
