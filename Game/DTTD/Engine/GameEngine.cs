namespace DTTD.Engine
{
    using Contracts;
    using Factory;
    using DuelToTheDeath.Class;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DuelToTheDeath.Interface;
    using Abstract;

    public class GameEngine : IEngine
    {
        private const string PlayerAlreadyExist = "Player {0} already exist. Choose a different username!";
        private const string PlayerRegisterеd = "Player {0} registered successfully!";
        private const string PlayerEquiped = "Player {0} equipped successfully with {1}!";
        private const string PlayerCast = "Player {0} has successfuly casted {1}!";
        private const string InvalidCommand = "{0} is not a valid command!";

        private static GameEngine thisInstance;

        private readonly ICollection<IPlayer> players;
        private readonly IPlayerFactory playerFactory;
        private readonly IItemFactory itemFactory;

        private GameEngine()
        {
            this.playerFactory = new PlayerFactory();
            this.itemFactory = new ItemFactory();
            this.players = new List<IPlayer>();
        }

        public static GameEngine Instance
        {
            get
            {
                if (thisInstance == null)
                {
                    thisInstance = new GameEngine();
                }

                return thisInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IEnumerable<IComand> ReadCommands()
        {
            var commands = new List<IComand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);
                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private List<string> ProcessCommands(IEnumerable<IComand> commands)
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
        }

        private string ProcessSingleCommand(IComand command)
        {
            string nameOfPlayer = (string)command.Parameters[1];

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
                    string enemyPlayer = command.Parameters[3];
                    if (command.Parameters.Count < 4)
                    {
                        return "Cast command should have 4 parameters"; // We could change this
                    }

                    string skillName = command.Parameters[2];

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

                    return string.Format(PlayerRegisterеd, nameOfPlayer);
                case "Mage":

                    var userMage = this.playerFactory.CreateMage(nameOfPlayer);

                    this.players.Add(userMage);

                    return string.Format(PlayerRegisterеd, nameOfPlayer);
                case "Rogue":

                    var userRogue = this.playerFactory.CreateRogue(nameOfPlayer);

                    this.players.Add(userRogue);

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
            //Selectors
            IPlayer player = this.players.FirstOrDefault(p => p.Name == nameOfPlayer);
            if(player == null)
            {
                throw new NullReferenceException("There is no such player in game.");
            }

            switch (player.ClassType)
            {
                case Enums.ClassType.Mage:
                    this.CastMage((Mage)player, skillName, enemyPlayer, nameOfPlayer);
                    return string.Format(PlayerCast, nameOfPlayer, skillName);
                case Enums.ClassType.Rogue:
                    this.CastRogue((Rogue)player, skillName, enemyPlayer, nameOfPlayer);
                    return string.Format(PlayerCast, nameOfPlayer, skillName);
                case Enums.ClassType.Warrior:
                    this.CastWarrior((Warrior)player, skillName, enemyPlayer, nameOfPlayer);
                    return string.Format(PlayerCast, nameOfPlayer, skillName);
                default:
                    throw new NotSupportedException("Not supported player.");
            } 
        }

        private void CastWarrior(Warrior warrior, string skillName, string enemyPlayer, string nameOfPlayer)
        {
            if (skillName == "CutByAxeAttack")
            {
                warrior.Target.Name = nameOfPlayer;
                
                warrior.CutByAxeAttack();
            }

            else if (skillName == "SpearAttack")
            {
                warrior.Target.Name = nameOfPlayer;

                warrior.SpearAttack();
            }

            else if (skillName == "BerserkMode")
            {
                warrior.BerserkMode();
            }

            else if (skillName == "UseShieldDefense")
            {
                warrior.Target.Name = nameOfPlayer;

                warrior.UseShieldDefense();
            }

            else if (skillName == "BlockAttackDefense")
            {
                warrior.BlockAttackDefense();
            }
        }

        private void CastRogue(Rogue rogue, string skillName, string enemyPlayer, string nameOfPlayer)
        {
            if (skillName == "BowAttack")
            {
                rogue.Target.Name = enemyPlayer;

                rogue.BowAttack();
            }

            else if (skillName == "SwordAttack")
            {
                rogue.Target.Name = enemyPlayer;

                rogue.SwordAttack();
            }

            else if (skillName == "DeadAttack")
            {
                rogue.Target.Name = enemyPlayer;

                rogue.DeadAttack();
            }

            else if (skillName == "ShieldDefense")
            {
                rogue.Target.Name = enemyPlayer;

                rogue.ShieldDefense();
            }

            else if (skillName == "DodgeAttackDefense")
            {
                rogue.DodgeAttackDefense();
            }

            else if (skillName == "CollectHealthPointsFromCorpses")
            {
                rogue.CollectHealthPointsFromCorpses();
            }

            else if (skillName == "TakeRestHealthRestorationk")
            {
                rogue.TakeRestHealthRestoration();
            }
        }

        private void CastMage(Mage mage, string skillName, string enemyPlayer, string nameOfPlayer)
        {
            if (skillName == "Heal")
            {
                mage.Heal();
            }

            else if (skillName == "BlackMagicAttack")
            {
                mage.Target.Name = enemyPlayer;

                mage.BlackMagicAttack();
            }

            else if (skillName == "DodgeAttackDefense")
            {
                mage.DodgeSingleAttack();
            }

            else if (skillName == "EnergyShieldDefense")
            {
                mage.EnergyShieldDefense();
            }

            else if (skillName == "WhiteMagicAttack")
            {
                mage.Target.Name = enemyPlayer;

                mage.WhiteMagicAttack();
            }

        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            Console.Write(output.ToString());
        }
    }
}
