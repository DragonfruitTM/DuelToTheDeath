using DTTD.Abstract;
using DTTD.Enums;
using DTTD.Factory;
using DuelToTheDeath.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTD.Engine
{
    public class GameEngine : IEngine
    {
        private const string PlayerAlreadyExist = "Player {0} already exist. Choose a different username!";
        private const string PlayerRegisterеd = "Player {0} registered successfully!";

        private ICollection<IPlayer> players;
        private IPlayerFactory factory;
        private static readonly IEngine SingleInstance = new GameEngine();
        public GameEngine()
        {
            this.factory = new PlayerFactory();
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

        private IList<string> ReadCommands()
        {
            var commands = new List<string>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = currentLine;
                commands.Add(currentCommand);
                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private List<string> ProcessCommands(IList<string> commands)
        {
            var reports = new List<string>();
            var factory = new PlayerFactory();

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

            foreach (var line in commands)
            {
                var currentCommandLine = line.Split(' ').ToArray();
                string nameOfPlayer = currentCommandLine[1];
                switch (currentCommandLine[0])
                {
                    case "Create":
                        if (this.players.Any(p => p.Name.ToLower() == nameOfPlayer.ToLower()))
                        {
                            Player loggedPlayer = (Player)(this.players.Where(p => p.Name.ToLower() == nameOfPlayer.ToLower()).Select(p => p));
                            reports.Add(string.Format(PlayerAlreadyExist, loggedPlayer.Name));
                        }

                        switch (currentCommandLine[2])
                        {
                            case "Warrior":
                                var userWarrior = this.factory.CreateWarrior(nameOfPlayer);
                                this.players.Add(userWarrior);
                                reports.Add(string.Format(PlayerRegisterеd, nameOfPlayer));
                                break;
                            case "Mage":
                                var userMage = this.factory.CreateMage(nameOfPlayer);
                                this.players.Add(userMage);
                                reports.Add(string.Format(PlayerRegisterеd, nameOfPlayer));
                                break;
                            case "Rogue":
                                var userRogue = this.factory.CreateRogue(nameOfPlayer);
                                this.players.Add(userRogue);
                                reports.Add(string.Format(PlayerRegisterеd, nameOfPlayer));
                                break;
                        }
                        break;

                    case "Equip":
                        if (currentCommandLine[2] == "Axe")
                        {
                            var axe = this.factory.EquipAxe(50);
                            axe.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += axe.AttackPoints);
                        }

                        else if (currentCommandLine[2] == "Bow")
                        {
                            var bow = this.factory.EquipBow(30);
                            bow.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += bow.AttackPoints);
                        }
                        else if (currentCommandLine[2] == "Hammer")
                        {
                            var hammer = this.factory.EquipHammer(20);
                            hammer.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += hammer.AttackPoints);
                        }
                        else if (currentCommandLine[2] == "Knife")
                        {
                            var knife = this.factory.EquipKnife(15);
                            knife.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += knife.AttackPoints);
                        }
                        else if (currentCommandLine[2] == "Sword")
                        {
                            var sword = this.factory.EquipSword(60);
                            sword.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.AttackPoints += sword.AttackPoints);
                        }
                        else if (currentCommandLine[2] == "Armor")
                        {
                            var armor = this.factory.EquipArmor(100);
                            armor.Owner = nameOfPlayer;
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p.DeffencePoints += armor.DefencePoints);
                        }
                        break;

                    case "Cast":
                        if (currentCommandLine[2] == "Heal")
                        {
                            this.players.Where(p => p.Name == nameOfPlayer).Select(p => p as Mage);                          
                        }

                        else if (currentCommandLine[2] == "Bow")
                        {
                            var bow = this.factory.EquipBow(30);
                            bow.Owner = nameOfPlayer;
                        }
                        else if (currentCommandLine[2] == "Hammer")
                        {
                            var hammer = this.factory.EquipHammer(20);
                            hammer.Owner = nameOfPlayer;
                        }
                        else if (currentCommandLine[2] == "Knife")
                        {
                            var knife = this.factory.EquipKnife(15);
                            knife.Owner = nameOfPlayer;
                        }
                        else if (currentCommandLine[2] == "Sword")
                        {
                            var sword = this.factory.EquipSword(60);
                            sword.Owner = nameOfPlayer;
                        }
                        else if (currentCommandLine[2] == "Armor")
                        {
                            var armor = this.factory.EquipArmor(100);
                            armor.Owner = nameOfPlayer;
                        }
                        break;
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
            }

            return reports;
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
