using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{

    public sealed class Player
{
        private static readonly Player instance = new Player();
        public struct Attributes
        {
            public static String Name;
            public static String Class;
            //Logistics
            public static int Gold;
            public static int Experience;
            public static int Experience_Required;
            public static int Level;
            //Combat
            public static int Health;
            public static int Current_Health;
            public static int Mana;
            public static string Status;
            //Location
            public static int X, Y;
            //public static implicit operator Attributes(string value)
            //{
            //    return new Attributes() { Experience = 0, Experience_Required = 100, Level = 1, Health = 100, currentHealth = 100, Mana = 50};
            //}
        }
        public void Add_Experience(int exp)
        {
            Attributes.Experience += exp;
        }
        public void Add_Gold(int gold)
        {
            Attributes.Gold += gold;
            if (Attributes.Gold < 0) Attributes.Gold = 0;
        }
        public void Add_Health(int bonus_Health)
        {
            Attributes.Health += bonus_Health;
        }
        public int Move(int y, int x)
        {
            if (x > 0 && x < 40 && y > 0 && y < 10)
            {
                Attributes.Y = y;
                Attributes.X = x;
                return 1;
            }
            else
            {
                var cw = new ConsoleWriter();
                cw.WriteMessage("You cannot go that way!", ConsoleColor.Red);
                return 0;
            }
        }
        public List<int> Get_Position()
        {
            List<int> position = new List<int>();
            position.Add(Attributes.Y);
            position.Add(Attributes.X);
            return position;
        }
        public List<int> Next_Position(int y, int x)
        {
            List<int> position = new List<int>();
            position.Add(y);
            position.Add(x);
            return position;
        }
        public bool LevelUp()
        {
            if (Attributes.Experience >= Attributes.Experience_Required)
            {
                Attributes.Experience_Required += 130;
                Attributes.Experience = 0;
                Attributes.Level++;
                Attributes.Health += 10;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MoveCheck(string command)
        {
            Dictionary<string, Tuple<int, int>> Commands = new Dictionary<string, Tuple<int, int>>()  {
                ["north"] = new Tuple<int, int>(0, Attributes.Y + 1),
                ["n"] = new Tuple<int, int>(0, Attributes.Y + 1),
                ["east"] = new Tuple<int, int>(Attributes.X + 1, 0),
                ["e"] = new Tuple<int, int>(Attributes.X + 1, 0),
                ["south"] = new Tuple<int, int>(0, Attributes.Y - 1),
                ["s"] = new Tuple<int, int>(0, Attributes.Y - 1),
                ["west"] = new Tuple<int, int>(Attributes.X - 1, 0),
                ["w"] = new Tuple<int, int>(Attributes.X - 1, 0),
            };
        }   
        public void DisplayAttributes()
        {
            var cw = new ConsoleWriter();
            string name = Attributes.Name;
            int health = (Attributes.Current_Health / Attributes.Health)*100, mana = Attributes.Mana, gold = Attributes.Gold;
            int nextlevel = Attributes.Experience_Required - Attributes.Experience;
            cw.WriteMessage("\n " + Attributes.Name , ConsoleColor.White);
            cw.WriteMessage("<<", ConsoleColor.DarkGray);

            if (health < (Attributes.Health / 2))
            {
                cw.WriteMessage("[", ConsoleColor.DarkGray);
                cw.WriteMessage(health.ToString(), ConsoleColor.Red);
                cw.WriteMessage("% : ", ConsoleColor.DarkGray);
                cw.WriteMessage("Health", ConsoleColor.White);
                cw.WriteMessage("]", ConsoleColor.DarkGray);
            }
            else
            {
                cw.WriteMessage("[", ConsoleColor.DarkGray);
                cw.WriteMessage(health.ToString(), ConsoleColor.Green);
                cw.WriteMessage("% : ", ConsoleColor.DarkGray);
                cw.WriteMessage("Health", ConsoleColor.White);
                cw.WriteMessage("]", ConsoleColor.DarkGray);
            }
            cw.WriteMessage("[", ConsoleColor.DarkGray);
            cw.WriteMessage(mana.ToString(), ConsoleColor.Green);
            cw.WriteMessage(" : ", ConsoleColor.DarkGray);
            cw.WriteMessage("MANA", ConsoleColor.White);
            cw.WriteMessage("]", ConsoleColor.DarkGray);
            cw.WriteMessage("[", ConsoleColor.DarkGray);
            cw.WriteMessage(gold.ToString() + " G", ConsoleColor.Yellow);
            cw.WriteMessage("]", ConsoleColor.DarkGray);
            cw.WriteMessage("[", ConsoleColor.DarkGray);
            cw.WriteMessage(nextlevel.ToString() + " XP", ConsoleColor.Yellow);
            cw.WriteMessage("]", ConsoleColor.DarkGray);
            cw.WriteMessage(">> \n", ConsoleColor.DarkGray);
        }
        public void RequestCommand(WorldRenderer worldRenderer)
        {
            var cw = new ConsoleWriter();
            var util = new RPGUtilities();
            string command;
            List<string> splitCommand;
            while (String.IsNullOrEmpty(command = Console.ReadLine()) || util.Split(command).Count() > 2)
            {
                Console.Clear();
                cw.WriteMessage("Invalid input ignored; please enter a valid command.\n", ConsoleColor.Red);
            }
            command = command.ToLower();
            int spaces = command.Count(Char.IsWhiteSpace);
            if (spaces == 0)
            {
                int option = util.ExecuteCommand(command);
                if (option == 0)
                {
                    cw.WriteMessage("\nNo such command detected\n", ConsoleColor.Red);
                    return;
                }
                if (option <= 4)
                {
                    Advance(option);

                }
                else if (option == 5)
                {
                    cw.WriteMessage("\n You take a good look around.\n", ConsoleColor.White);
                    Thread.Sleep(1500);
                    if (worldRenderer.GetStrategy() == 1)
                    {
                        worldRenderer.SetStrategy(new BasicRenderStrategy(), 1);
                        
                    }
                    else
                    {
                        worldRenderer.SetStrategy(new DemonRenderStrategy(), 2);
                    }
                    worldRenderer.Render(Get_Position()[0], Get_Position()[1]);
                }
                else if (option == 6)
                {
                    cw.WriteMessage("\n You seek the gods for guidance.\n", ConsoleColor.White);
                    Thread.Sleep(1500);
                    util.HelpMenu();
                }
                else if (option == 11)
                {
                    if (worldRenderer.GetStrategy() == 1)
                    {
                        cw.WriteMessage("\n You take the form of a demon; you may now fly over terrain. \n", ConsoleColor.White);
                        Thread.Sleep(1500);
                        worldRenderer.SetStrategy(new DemonRenderStrategy(),2);
                        Player.Attributes.Mana -= 10;
                    }
                    else
                    {
                        cw.WriteMessage("\n You return to your human form. \n", ConsoleColor.White);
                        Thread.Sleep(1500);
                        worldRenderer.SetStrategy(new BasicRenderStrategy(),1);
                    }
                    worldRenderer.Render(Get_Position()[0], Get_Position()[1]);
                }
                else if (option == 12)
                {
                    cw.WriteMessage("\n You reflect on your current condition.\n", ConsoleColor.White);
                    Thread.Sleep(1500);
                    var pa = new PlayerAdapter(Player.instance);
                    pa.GetScore();
                }
            }
        }
        public void Advance(int command)
        {
            var util = new RPGUtilities();
            var cw = new ConsoleWriter();
            int ordinate_y = 0, ordinate_x = 0, tile;
            string arrival = string.Empty, departure = string.Empty;
            switch (command)
            {
                case 1:
                    ordinate_y = Get_Position()[0] - 1; ordinate_x = Get_Position()[1];
                    departure = "\n You leave to the north.\n";
                    arrival = "\n You arrive from the south.\n";
                    break;
                case 2:
                    ordinate_y = Get_Position()[0]; ordinate_x = Get_Position()[1] + 1;
                    departure = "\n You leave to the east.\n";
                    arrival = "\n You arrive from the west.\n";
                    break;
                case 3:
                    ordinate_y = Get_Position()[0] + 1; ordinate_x = Get_Position()[1];
                    departure = "\n You leave to the south.\n";
                    arrival = "\n You arrive from the north.\n";
                    break;
                case 4:
                    ordinate_y = Get_Position()[0]; ordinate_x = Get_Position()[1] - 1;
                    departure = "\n You leave to the west.\n";
                    arrival = "\n You arrive from the east.\n";
                    break;
            }
            tile = World.Instance.GetWorld()[ordinate_y, ordinate_x];
            if (util.CheckMove(tile) == 1)
            {
                if (Move(ordinate_y, ordinate_x) != 0)
                {
                    cw.WriteMessage(departure, ConsoleColor.Gray);
                    Thread.Sleep(2000);
                    //Game_State.empty_MonsterCache();
                    Console.Clear();
                    cw.WriteMessage(arrival, ConsoleColor.Gray);
                    var worldRenderer = new WorldRenderer();
                    worldRenderer.Render(Get_Position()[0], Get_Position()[1]);
                    var enemy = new Monster();
                    enemy.Encounter(tile);
                    //Game_State.empty_MonsterCache();
                    //Cell.get_Info(tile);
                    //Encounter(tile);
                    //Format.Pseudo_Clear(5);
                }
            }
        }
        public string GetName(){return Player.Attributes.Name;}
        public int GetGold(){return Player.Attributes.Gold;}
        public int GetLevel() { return Player.Attributes.Level; }
        public int GetHealth() { return Player.Attributes.Health; }
        public int GetCurrentHealth() { return Player.Attributes.Current_Health; }
        public int GetMana() { return Player.Attributes.Mana; }
        public int GetExp() { return Player.Attributes.Experience; }

        static Player() {
            Attributes.Experience = 0; Attributes.Experience_Required = 100; Attributes.Level = 1; Attributes.Health = 100; Attributes.Current_Health = 100; Attributes.Mana = 50;
        }

        private Player(){}

        public static Player Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
