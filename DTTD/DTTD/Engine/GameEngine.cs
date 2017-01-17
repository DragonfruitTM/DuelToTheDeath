using System;
using System.Collections.Generic;
using System.Linq;
using DuelToTheDeath.Contracts;
using DuelToTheDeath.Factory;
using DuelToTheDeath.Enums;
using DuelToTheDeath.Models.Items;

namespace DuelToTheDeath.Engine
{
    public class GameEngine : IEngine
    {
        private const string PlayerAlreadyExist = "Player {0} already exist. Choose a different username!";
        private const string PlayerRegisterеd = "Player {0} registered successfully!";
        private const string PlayerDead = "Player {0} has been killed by {1}!";
        private const string PlayerEquiped = "Player {0} equipped successfully with {1}!";
        private const string PlayerCast = "Player {0} has successfuly casted {1}!";
        private const string InvalidCommand = "{0} is not a valid command!";

        private static IEngine SingleInstance;

        private ICommandReader reader;
        private ILogger logger;

        private ICollection<IPlayer> players;

        private ICollection<IMageSkills> mages;
        private ICollection<IRogueSkills> rogues;
        private ICollection<IWarriorSkills> warriors;

        private IPlayerFactory playerFactory;

        private GameEngine(ICommandReader reader, ILogger logger)
        {
            if (reader == null)
            {
                throw new NullReferenceException("CommandReader should not be null!");
            }
            this.reader = reader;

            if (logger == null)
            {
                throw new NullReferenceException("Logger should not be null!");
            }
            this.logger = logger;

            this.playerFactory = new PlayerFactory();

            this.players = new List<IPlayer>();

            this.mages = new List<IMageSkills>();
            this.rogues = new List<IRogueSkills>();
            this.warriors = new List<IWarriorSkills>();
        }
        
        public static IEngine Initialise (ICommandReader reader, ILogger loger)
        {
            if (SingleInstance == null)
            {
                SingleInstance = new GameEngine(reader, loger);
            }

            return SingleInstance;
        }

        public void Start()
        {
            this.logger.Log("Please, create at least two players.");
            this.logger.Log("To create a player, enter: Create (PlayerName) (Class) (Race)");

            var currentCommand = this.reader.ReadCommand();

            while (currentCommand.ToLower() != "exit")
            {
                try
                {
                    var command = this.CommandParse(currentCommand);
                    var commandResult = this.ProcessSingleCommand(command);
                    this.logger.Log(commandResult);
                }
                catch (Exception ex)
                {
                    this.logger.Log(ex.Message);
                }

                currentCommand = this.reader.ReadCommand();
            }
        }

        private IComand CommandParse(string currentCommand)
        {
            return new Command(currentCommand);
        }
        
        private string ProcessSingleCommand(IComand command)
        {
            string nameOfPlayer = command.Parameters[1];

            switch (command.Parameters[0])
            {
                case "Create":
                    if (command.Parameters.Count < 3)
                    {
                        return "Create command should have 3 parameters";
                    }

                    string typeOfPlayer = command.Parameters[2];

                    return this.CreatePlayer(nameOfPlayer, typeOfPlayer);

                case "Equip":
                    if (command.Parameters.Count < 3)
                    {
                        return "Equip command should have 3 parameters";
                    }

                    string typeOfItem = command.Parameters[2];

                    return this.EquipPlayer(nameOfPlayer, typeOfItem);

                case "Cast":
                    if (command.Parameters.Count < 4)
                    {
                        return "Cast command should have 4 parameters";
                    }

                    string skillName = command.Parameters[2];
                    string enemyPlayer = command.Parameters[3];

                    return this.CastPlayer(nameOfPlayer, skillName, enemyPlayer);
            }

            return string.Format(InvalidCommand, command.Parameters[0]);
        }

        private void OnPlayerDeath(object sender, DeadPlayerEventArgs args)
        {
            if (this.players.Remove(args.playerToRemove))
            {
                this.logger.Log(string.Format(PlayerDead, args.playerToRemove.Name, args.killerName));


                switch (args.playerToRemove.ClassType)
                {
                    case Enums.ClassType.Mage:

                        IMageSkills mageToRemove = this.mages.SingleOrDefault(m => m.Name == args.playerToRemove.Name);
                        this.mages.Remove(mageToRemove);
                        break;

                    case Enums.ClassType.Rogue:

                        IRogueSkills rogueToRemove = this.rogues.SingleOrDefault(r => r.Name == args.playerToRemove.Name);
                        this.rogues.Remove(rogueToRemove);
                        break;

                    case Enums.ClassType.Warrior:

                        IWarriorSkills wariorToRemove = this.warriors.SingleOrDefault(w => w.Name == args.playerToRemove.Name);
                        this.warriors.Remove(wariorToRemove);
                        break;

                    default:
                        break;
                }
            }
        } 

        private string CreatePlayer(string nameOfPlayer, string typeOfPlayer)
        {
            if (this.players.Any(p => p.Name.ToLower() == nameOfPlayer.ToLower()))
            {
                return string.Format(PlayerAlreadyExist, nameOfPlayer);
            }

            switch (typeOfPlayer)
            {
                case "Warrior":

                    var userWarrior = this.playerFactory.CreateWarrior(nameOfPlayer);
                    userWarrior.playerDeath += this.OnPlayerDeath;
                    this.players.Add(userWarrior);
                    this.warriors.Add(userWarrior);

                    return string.Format(PlayerRegisterеd, nameOfPlayer);
                case "Mage":

                    var userMage = this.playerFactory.CreateMage(nameOfPlayer);

                    this.players.Add(userMage);
                    this.mages.Add(userMage);

                    return string.Format(PlayerRegisterеd, nameOfPlayer);
                case "Rogue":

                    var userRogue = this.playerFactory.CreateRogue(nameOfPlayer);

                    this.players.Add(userRogue);
                    this.rogues.Add(userRogue);

                    return string.Format(PlayerRegisterеd, nameOfPlayer);
            }

            return "You don't have the ability to create such a player in this version of the game";
        }
        
        private string EquipPlayer(string nameOfPlayer, string typeOfItem) 
        {
            ItemType itemType;

            if (Enum.TryParse<ItemType>(typeOfItem, out itemType))
            {
                IItem itemToEquip = new Item(itemType);
                IPlayer playerToEquip = this.players.SingleOrDefault(p => p.Name == nameOfPlayer);
                playerToEquip.Equip(itemToEquip);

                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            return string.Format("There's no such item like {0}", typeOfItem);
        }

        private string CastPlayer(string nameOfPlayer, string skillName, string enemyPlayer)
        {
            IPlayer enemy = this.players.SingleOrDefault(p => p.Name == enemyPlayer);

            //Mage Skills
            if (skillName == "Heal")
            {
                this.mages.SingleOrDefault(m => m.Name == nameOfPlayer).Heal();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "BlackMagicAttack")
            {
                this.mages.SingleOrDefault(m => m.Name == nameOfPlayer).BlackMagicAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "DodgeAttackDefense")
            {
                this.mages.SingleOrDefault(m => m.Name == nameOfPlayer).DodgeSingleAttack();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "EnergyShieldDefense")
            {
                this.mages.SingleOrDefault(m => m.Name == nameOfPlayer).EnergyShieldDefense();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "WhiteMagicAttack")
            {
                this.mages.SingleOrDefault(m => m.Name == nameOfPlayer).WhiteMagicAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            //Warrior Skills
            else if (skillName == "CutByAxeAttack")
            {
                this.warriors.SingleOrDefault(m => m.Name == nameOfPlayer).CutByAxeAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "SpearAttack")
            {
                this.warriors.SingleOrDefault(m => m.Name == nameOfPlayer).SpearAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "BerserkMode")
            {
                this.warriors.SingleOrDefault(m => m.Name == nameOfPlayer).BerserkMode();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "UseShieldDefense")
            {
                this.warriors.SingleOrDefault(m => m.Name == nameOfPlayer).UseShieldDefense(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "BlockAttackDefense")
            {
                this.warriors.SingleOrDefault(m => m.Name == nameOfPlayer).BlockAttackDefense();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            //Rogue Skills
            else if (skillName == "BowAttack")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).BowAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "SwordAttack")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).SwordAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "DeadAttack")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).DeadAttack(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "ShieldDefense")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).ShieldDefense(enemy);

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "DodgeAttackDefense")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).DodgeAttackDefense();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "CollectHealthPointsFromCorpses")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).CollectHealthPointsFromCorpses();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            else if (skillName == "TakeRestHealthRestorationk")
            {
                this.rogues.SingleOrDefault(m => m.Name == nameOfPlayer).TakeRestHealthRestoration();

                return string.Format(PlayerCast, nameOfPlayer, skillName);
            }

            return string.Format("There's no such skill for you to cast.");
        }
    }
}
