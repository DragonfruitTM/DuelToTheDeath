using DTTD.Abstract;
using DTTD.Enums;
using DTTD.Contracts;
using DTTD.Factory;
using DuelToTheDeath.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTTD.Engine
{
    public class GameEngine : IEngine
    {
        private const string PlayerAlreadyExist = "Player {0} already exist. Choose a different username!";
        private const string PlayerRegisterеd = "Player {0} registered successfully!";
        private const string PlayerEquiped = "Player {0} equipped successfully with {1}!";
        private const string InvalidCommand = "{0} is not a valid command!";

        private static readonly IEngine SingleInstance = new GameEngine();

        private ICollection<IPlayer> players;
        private IPlayerFactory playerFactory;
        private IItemFactory itemFactory;

        private GameEngine()
        {
            this.playerFactory = new PlayerFactory();
            this.itemFactory = new ItemFactory();
            this.players = new List<IPlayer>();
        }

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
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
            string nameOfPlayer;

            switch (command.Parameters[0])
            {
                case "Create":
                    if (command.Parameters.Count < 3)
                    {
                        return "Create command should have 3 parameters"; // We could change this
                    }
                    nameOfPlayer = command.Parameters[1];
                    string typeOfPlayer = command.Parameters[2];
                    return this.CreatePlayer(nameOfPlayer, typeOfPlayer);

                case "Equip":
                    if (command.Parameters.Count < 3)
                    {
                        return "Equip command should have 3 parameters"; // We could change this
                    }
                    nameOfPlayer = command.Parameters[1];
                    string typeOfItem = command.Parameters[2];
                    return this.EquipPlayer(nameOfPlayer, typeOfItem);

                case "Cast":
                    if (command.Parameters.Count < 3)
                    {
                        return "Cast command should have 2 more parameters"; // We could change this
                    }
                    nameOfPlayer = command.Parameters[1];
                    string typeOfCast = command.Parameters[2];
                    return this.CastPlayer(nameOfPlayer, typeOfCast);
            }

            return string.Format(InvalidCommand, command.Parameters[0]);
        }

        //Trqbva da se napravi taka che IUnit da se setva na name of player, koito shte e string.
        //Ili propertyto mu da se promeni na string 
        // TODO: How do you set owner to weapon ????!! some help.....
        //  if (currentCommandLine[0] == "Create")
        //  {
        //      if (currentCommandLine[2] == "Ork")
        //      {
        //          this.factory.CreateWarrior(nameOfPlayer);
        //          reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Warrior"));
        //      }
        //
        //      else if (currentCommandLine[2] == "Human")
        //      {
        //          this.factory.CreateMage(nameOfPlayer);
        //          reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Mage"));
        //      }
        //
        //      else if (currentCommandLine[2] == "Undead")
        //      {
        //          this.factory.CreateRogue(nameOfPlayer);
        //          reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Rogue"));
        //      }
        //  }


        //   else if(currentCommandLine[0] == "Cast")
        //   {
        //       if (currentCommandLine[2] == "Heal")
        //       {
        //           //this.factory.CreateMage.Heal();
        //       }
        //       else if (currentCommandLine[2] == " BlackMagicAttack")
        //       {
        //           //this.factory.CreateMage.BlackMagicAttack();
        //       }
        //       else if(currentCommandLine[2] == "DodgeAttackDefense")
        //       {
        //           //this.factory.CreateMage.DodgeAttackDefense();
        //       }
        //       else if(currentCommandLine[2]== "EnergyShieldDefense")
        //       {
        //           //this.factory.CreateMage.EnergyShieldDefense();
        //       }
        //       else if(currentCommandLine[2]== "WhiteMagicAttack")
        //       {
        //           //this.factory.CreateMage.WhiteMagicAttack();
        //       }
        //   }

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
            return "You do't have the ability to create such player in this version of the game";
        }

        private string EquipPlayer(string nameOfPlayer, string typeOfItem) 
        {
            if (typeOfItem == "Axe")
            {
                var axe = this.itemFactory.EquipAxe(50);
                axe.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += axe.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            else if (typeOfItem == "Bow")
            {
                var bow = this.itemFactory.EquipBow(30);
                bow.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += bow.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }
            else if (typeOfItem == "Hammer")
            {
                var hammer = this.itemFactory.EquipHammer(20);
                hammer.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += hammer.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }
            else if (typeOfItem == "Knife")
            {
                var knife = this.itemFactory.EquipKnife(15);
                knife.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += knife.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }
            else if (typeOfItem == "Sword")
            {
                var sword = this.itemFactory.EquipSword(60);
                sword.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += sword.AttackPoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }
            else if (typeOfItem == "Armor")
            {
                var armor = this.itemFactory.EquipArmor(100);
                armor.Owner = nameOfPlayer;
                this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.DeffencePoints += armor.DefencePoints);
                return string.Format(PlayerEquiped, nameOfPlayer, typeOfItem);
            }

            return string.Format("There's no such item like {0}", typeOfItem);
        }

        private string CastPlayer(string nameOfPlayer, string typeOfCast)
        {
            if (typeOfCast == "Heal")
            {
                foreach (var player in players)
                {
                    if(player.Name == nameOfPlayer)
                    {
                        Mage mage = (Mage)player;
                        mage.Heal();
                    }
                }
            }
            else if (typeOfCast == " BlackMagicAttack")
            {
                //this.factory.CreateMage.BlackMagicAttack();
            }
            else if (typeOfCast == "DodgeAttackDefense")
            {
                //this.factory.CreateMage.DodgeAttackDefense();
            }
            else if (typeOfCast == "EnergyShieldDefense")
            {
                //this.factory.CreateMage.EnergyShieldDefense();
            }
            else if (typeOfCast == "WhiteMagicAttack")
            {
                //this.factory.CreateMage.WhiteMagicAttack();
            }
        }

    }
}
