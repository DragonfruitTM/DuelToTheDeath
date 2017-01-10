using DTTD.Factory;
using DuelToTheDeath.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTD.Engine
{
   public class GameEngine
    {
        private IPlayerFactory factory;
        public GameEngine()
        {
            this.factory = new PlayerFactory();
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

            foreach (var line in commands)
            {
                var currentCommandLine = line.Split(' ').ToArray();
                string nameOfPlayer = currentCommandLine[1];

                if (currentCommandLine[0] == "Create")
                {
                    if (currentCommandLine[2] == "Ork")
                    {
                       this.factory.CreateWarrior(nameOfPlayer);
                        reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Warrior"));
                    }

                    else if (currentCommandLine[2] == "Human")
                    {
                      this.factory.CreateMage(nameOfPlayer);
                        reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Mage"));
                    }

                    else if (currentCommandLine[2] == "Undead")
                    {
                      this.factory.CreateRogue(nameOfPlayer);
                        reports.Add(string.Format("{0} has created himself a {1}!", nameOfPlayer, "Rogue"));
                    }
                }

                //Trqbva da se napravi taka che IUnit da se setva na name of player, koito shte e string.
                //Ili propertyto mu da se promeni na string 
                // TODO: How do you set owner to weapon ????!! some help.....

                else if (currentCommandLine[0] == "Equip")
                {
                    
                    if (currentCommandLine[2] == "Axe")
                    {
                        this.factory.EquipAxe(50);
                    }

                    else if (currentCommandLine[2] == "Bow")
                    {
                        this.factory.EquipBow(30);
                    }
                    else if (currentCommandLine[2] == "Hammer")
                    {
                        this.factory.EquipHammer(20);
                    }
                    else if (currentCommandLine[2] == "Knife")
                    {
                        this.factory.EquipKnife(15);
                    }
                    else if (currentCommandLine[2] == "Sword")
                    {
                        this.factory.EquipSword(60);
                    }
                }

                else if(currentCommandLine[0] == "Cast")
                {
                    if (currentCommandLine[2] == "Heal")
                    {
                        //this.factory.CreateMage.Heal();
                    }
                    else if (currentCommandLine[2] == " BlackMagicAttack")
                    {
                        //this.factory.CreateMage.BlackMagicAttack();
                    }
                    else if(currentCommandLine[2] == "DodgeAttackDefense")
                    {
                        //this.factory.CreateMage.DodgeAttackDefense();
                    }
                    else if(currentCommandLine[2]== "EnergyShieldDefense")
                    {
                        //this.factory.CreateMage.EnergyShieldDefense();
                    }
                    else if(currentCommandLine[2]== "WhiteMagicAttack")
                    {
                        //this.factory.CreateMage.WhiteMagicAttack();
                    }
                }
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
