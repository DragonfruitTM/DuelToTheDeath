namespace DTTD.Engine
{
    using Contracts;
    using Factory;
    using DuelToTheDeath.Class;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameEngine : IEngine
    {
        private const string PlayerAlreadyExist = "Player {0} already exist. Choose a different username!";
        private const string PlayerRegisterеd = "Player {0} registered successfully!";
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
        private IItemFactory itemFactory;

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
            this.itemFactory = new ItemFactory();
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
            var currentCommand = this.reader.ReadCommand();

            while (!string.IsNullOrEmpty(currentCommand))
            {
                var command = this.CommandParse(currentCommand);
                var commandResult = this.ProcessSingleCommand(command);
                this.logger.Log(commandResult);
                currentCommand = this.reader.ReadCommand();
            }
        }

        private IComand CommandParse(string currentCommand)
        {
            return new Command(currentCommand);
        }

      /*private List<string> ProcessCommands(IEnumerable<IComand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }*/

        private string ProcessSingleCommand(IComand command)
        {
            string nameOfPlayer = command.Parameters[1];

            switch (command.Parameters[0])
            {
                case "Create":
                    if (command.Parameters.Count < 3)
                    {
                        return "Create command should have 3 parameters"; // We could change this
                    }

                    string typeOfPlayer = command.Parameters[2];

                    return this.CreatePlayer(nameOfPlayer, typeOfPlayer);

                case "Equip":
                    if (command.Parameters.Count < 3)
                    {
                        return "Equip command should have 3 parameters"; // We could change this
                    }

                    string typeOfItem = command.Parameters[2];

                    return this.EquipPlayer(nameOfPlayer, typeOfItem);

                case "Cast":
                    if (command.Parameters.Count < 4)   // We do not need enemy player for some of the methods
                    {
                        return "Cast command should have 4 parameters"; // We could change this
                    }

                    string skillName = command.Parameters[2];
                    string enemyPlayer = command.Parameters[3];

                    return this.CastPlayer(nameOfPlayer, skillName, enemyPlayer);
            }

            return string.Format(InvalidCommand, command.Parameters[0]);
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

            // We could change this swith-case construction to something more appropriate
            return "You don't have the ability to create such a player in this version of the game";
        }

        private string EquipPlayer(string nameOfPlayer, string typeOfItem) 
        {
            if (typeOfItem == "Axe")
            {
                var axe = this.itemFactory.EquipAxe(50);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += axe.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Bow")
            {
                var bow = this.itemFactory.EquipBow(30);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += bow.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Hammer")
            {
                var hammer = this.itemFactory.EquipHammer(20);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += hammer.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Knife")
            {
                var knife = this.itemFactory.EquipKnife(15);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += knife.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Sword")
            {
                var sword = this.itemFactory.EquipSword(60);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += sword.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Armor")
            {
                var armor = this.itemFactory.EquipArmor(100);

                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.DeffencePoints += armor.DefencePoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            return string.Format("There's no such item like {0}", typeOfItem);
        }

        private string CastPlayer(string nameOfPlayer, string skillName, string enemyPlayer)
        {
            // We do not need enemy player for some of the methods
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

      /*private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            Console.Write(output.ToString());
        }*/
    }
}
