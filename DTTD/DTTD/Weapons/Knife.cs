
using System;

public class Knife : IUnit
{
    private int attackPoints;
    private IUnit owner;    //IUnit

    public Knife(int attackPoints)
    {
        this.attackPoints = attackPoints;
        this.Owner = owner;
    }

    public int AttackPoints
    {
        get
        {
            return this.attackPoints;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("AttackPoints can not be negative!");
            }

            this.attackPoints = value;
        }
    }

    public IUnit Owner
    {
        get
        {
            return this.owner;
        }

        set
        {
            if (value == null)
            {
                throw new NullReferenceException("Owner can not be null!");
            }

            this.owner = value;
        }
    }

}

