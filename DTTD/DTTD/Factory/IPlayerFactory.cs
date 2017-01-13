namespace DTTD.Factory
{
    using DTTD.Contracts;

    public interface IPlayerFactory
    {
        IWarriorSkills CreateWarrior(string name);
        IMageSkills CreateMage(string name);
        IRogueSkills CreateRogue(string name);
    }
}