using System;

public abstract class Ork
{
    private string orkName;
    private const int InitialOrkHitPoints = 1000;
    private const int InitialOrkAttackPoints = 20;
    private const int InitialOrkDeffencePoints = 200;
    private const int InitialOrkHpRegeneration = 20;

    public Ork(string orkName)
    {
        this.OrkName = orkName;
        this.HitPoints = InitialOrkHitPoints;
        this.AttackPoints = InitialOrkAttackPoints;
        this.DeffencePoints = InitialOrkDeffencePoints;
        this.HPRegeneration = InitialOrkHpRegeneration;
    }

    public string OrkName
    {
        get
        {
            return this.orkName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException();
            }

            if (value.Substring(0, 4) != "RAzN_")
            {
                throw new ArgumentException();
            }

            this.orkName = value;
        }
    }

    public int HitPoints { get; set; }
    public int DeffencePoints { get; set; }
    public int HPRegeneration { get; set; }
    public int AttackPoints { get; set; }
}
