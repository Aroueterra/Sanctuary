using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int counter = 0;
            bool Playing = false;
            Player.Instance.Move(8, 3);
            Player.Attributes.Name = "Vendredi";
            var worldRenderer = new WorldRenderer();
            var util = new RPGUtilities();
            util.HelpMenu();
            Console.WriteLine("Get started by entering a command.");
            Console.WriteLine("Try the [look] command. You are the @ symbol in the map.");
            while (!(Playing))
            {
                worldRenderer.SetStrategy(new BasicRenderStrategy(),1);
                Player.Instance.RequestCommand(worldRenderer);
                counter++;
                if (counter == 1000) Playing = true;
            }

            //ConsoleWriter cw = new ConsoleWriter();
            //var worldRenderer = new WorldRenderer();
            //Player.Attributes.Name = "Bob";

            //Console.WriteLine("Render Mode: Basic");
            //worldRenderer.SetStrategy(new BasicRenderStrategy());
            //worldRenderer.Render();

            //Console.WriteLine();

            //Console.WriteLine("Render Mode: Dark");
            //worldRenderer.SetStrategy(new DemonRenderStrategy());
            //worldRenderer.Render();
            //Console.WriteLine("An ASCII Fantasy Map via "); cw.WriteMessage("Multi-Dimensional Matrix", ConsoleColor.Red);
            //Console.WriteLine("");
            //Player.Attributes.Name = "2";
            //Console.WriteLine(Player.Attributes.Name + " = exp");
            //Console.WriteLine(Player.Instance.add_Experience(2) + " = exp");
            Console.ReadLine();
        }

        //void Receive_Command()
        //{
        //    Colorize Format;
        //    string command;
        //    vector<string> split_Command;
        //    while (!(getline(cin, command)) || Split(command).size() > 2)
        //    {
        //        cin.clear();
        //        cin.ignore(numeric_limits < streamsize >::max(), '\n');
        //        Format.Paint(12, "Invalid input ignored; please enter a valid command.", "\n");
        //    }
        //    command = Format.Lower(command);
        //    string c;
        //    int counter = 0;
        //    for (char & c : command)
        //    {
        //        if (isspace(c))
        //        {
        //            counter++;
        //        }
        //    }
        //    if (counter == 0)
        //    {
        //        int ordinate_x, ordinate_y, tile;
        //        map<string, int>::iterator itr = Command_List.find(command);
        //        int option;
        //        if (itr != Command_List.end())
        //        {
        //            option = itr->second;//Command_List.find(command)->second;
        //        }
        //        else
        //        {
        //            cout << "\nNo such command detected\n";
        //            return;
        //        }
        //        if (option == 1)
        //        {
        //            ordinate_y = Player.get_Position()[0] - 1; ordinate_x = Player.get_Position()[1];
        //            tile = World.get_Map_Tile(ordinate_y, ordinate_x);
        //            if (CheckMove(tile) == 1)
        //            {
        //                if (Player.set_Position(ordinate_y, ordinate_x) != 0)
        //                {
        //                    Format.Paint(8, "\n You leave to the north.", "\n");
        //                    Sleep(1500);
        //                    Game_State.empty_MonsterCache();
        //                    Format.Pseudo_Clear(1);
        //                    Format.Paint(8, "\n You arrive from the south.", "\n");
        //                    World.Reveal(Player.get_Position()[0], Player.get_Position()[1]);
        //                    //Game_State.empty_MonsterCache();
        //                    Cell.get_Info(tile);
        //                    Encounter(tile);
        //                    Format.Pseudo_Clear(5);
        //                }
        //            }

        //        }
        //        else if (option == 2)
        //        {
        //            ordinate_y = Player.get_Position()[0]; ordinate_x = Player.get_Position()[1] + 1;
        //            tile = World.get_Map_Tile(ordinate_y, ordinate_x);
        //            if (CheckMove(tile) == 1)
        //            {
        //                if (Player.set_Position(ordinate_y, ordinate_x) != 0)
        //                {
        //                    Format.Paint(8, "\n You leave to the east.", "\n");
        //                    Sleep(1500);
        //                    Game_State.empty_MonsterCache();
        //                    Format.Pseudo_Clear(1);
        //                    Format.Paint(8, "\n You arrive from the west.", "\n");
        //                    World.Reveal(Player.get_Position()[0], Player.get_Position()[1]);
        //                    Cell.get_Info(tile);
        //                    Encounter(tile);
        //                    Format.Pseudo_Clear(5);
        //                }
        //            }
        //        }
        //        else if (option == 3)
        //        {
        //            ordinate_y = Player.get_Position()[0] + 1; ordinate_x = Player.get_Position()[1];
        //            tile = World.get_Map_Tile(ordinate_y, ordinate_x);
        //            if (CheckMove(tile) == 1)
        //            {
        //                if (Player.set_Position(ordinate_y, ordinate_x) != 0)
        //                {
        //                    Format.Paint(8, "\n You leave to the south.", "\n");
        //                    Sleep(1500);
        //                    Game_State.empty_MonsterCache();
        //                    Format.Pseudo_Clear(1);
        //                    Format.Paint(8, "\n You arrive from the north.", "\n");
        //                    World.Reveal(Player.get_Position()[0], Player.get_Position()[1]);
        //                    Cell.get_Info(tile);
        //                    Encounter(tile);
        //                    Format.Pseudo_Clear(5);
        //                }
        //            }
        //        }
        //        else if (option == 4)
        //        {
        //            ordinate_y = Player.get_Position()[0]; ordinate_x = Player.get_Position()[1] - 1;
        //            tile = World.get_Map_Tile(ordinate_y, ordinate_x);
        //            if (CheckMove(tile) == 1)
        //            {
        //                if (Player.set_Position(ordinate_y, ordinate_x) != 0)
        //                {
        //                    Format.Paint(8, "\n You leave to the west.", "\n");
        //                    Sleep(1500);
        //                    Game_State.empty_MonsterCache();
        //                    Format.Pseudo_Clear(1);
        //                    Format.Paint(8, "\n You arrive from the east.", "\n");
        //                    World.Reveal(Player.get_Position()[0], Player.get_Position()[1]);
        //                    Cell.get_Info(tile);
        //                    Encounter(tile);
        //                    Format.Pseudo_Clear(5);
        //                }
        //            }
        //        }
        //        else if (option == 5)
        //        {
        //            Format.Paint(7, "\n You take a good look around.", "\n");
        //            Sleep(1500);
        //            Format.Pseudo_Clear(1);
        //            World.Reveal(Player.get_Position()[0], Player.get_Position()[1]);
        //        }
        //        else if (option == 6)
        //        {
        //            Format.Paint(7, "\n You pray to the gods for guidance.", "\n");
        //            Sleep(1500);
        //            Help();
        //        }
        //        else if (option == 7)
        //        {
        //            if (Player.get_Job() == "Warlock")
        //            {
        //                Format.Paint(11, "\n You pray to the gods for healing.", "\n");
        //                Sleep(1500);
        //                Player.Heal();
        //            }
        //            else
        //            {
        //                Sleep(1500);
        //                Format.Paint(12, "\n This spell is only available to the warlock class", "\n");
        //            }
        //        }
        //    }
        //    else if (counter > 0 && counter < 2)
        //    {
        //        split_Command = Split(command);
        //        string command_1, command_2;
        //        command_1 = split_Command[0];
        //        command_2 = split_Command[1];
        //        int option;
        //        string monsterName;
        //        map<string, int>::iterator itr = Command_List.find(command_1);
        //        if (itr != Command_List.end())
        //        {
        //            option = itr->second;
        //        }
        //        else
        //        {
        //            cout << "\nNo such command detected\n";
        //            return;
        //        }
        //        if (option == 8)
        //        {
        //            Format.Paint(7, "\n You get the item.", "\n");
        //            Sleep(1500);
        //        }
        //        else if (option == 9)
        //        {
        //            if (!Game_State.get_MonsterCache().empty())
        //            {
        //                monsterName = Game_State.get_MonsterCache()[0].get_Name();
        //                monsterName = Format.Lower(monsterName);
        //                if (monsterName == command_2)
        //                {
        //                    Format.Paint(7, "\n You attack the ", command_2);
        //                    int HP = Player.get_Health(), MP = Player.get_Mana(), CHP = Player.get_cHealth();
        //                    int MHP = Game_State.get_MonsterCache()[0].get_MaxHealth();
        //                    int MType = Game_State.get_MonsterCache()[0].get_Type();
        //                    int Plvl = Player.get_Level();
        //                    Sleep(2000);
        //                    Fight.Setup(HP, CHP, MP, MHP, MType, monsterName, Plvl);
        //                    bool Result = Fight.Battle();
        //                    cin.clear();
        //                    cin.ignore(numeric_limits < streamsize >::max(), '\n');
        //                    if (Result)
        //                    {
        //                        Player.set_Health(Fight.Recover()[0]);
        //                        Player.set_Mana(Fight.Recover()[1]);
        //                        int xp = Fight.Recover()[2] * 10 + (rand() % ((Fight.Recover()[2] * 10) + 1) + 1);
        //                        int gold = Fight.Recover()[2] + (rand() % ((Fight.Recover()[2] * 5) + 1) + 1);
        //                        Player.add_Experience(xp);
        //                        Player.add_Gold(gold);
        //                        Format.WorldPaint(12, "\n The "); cout << monsterName; Format.WorldPaint(12, " falls lifeless at your feet.\n");
        //                        Format.WorldPaint(14, "\n You gained "); cout << gold; Format.WorldPaint(14, " gold, and "); cout << xp; Format.WorldPaint(14, " experience for your efforts!\n");
        //                        if (Player.levelup_Player())
        //                        {
        //                            Format.WorldPaint(14, "\n You've gained a level! You are now level: "); cout << Player.get_Level();
        //                            Player.add_Health(25);
        //                            Player.add_Mana(25);
        //                            Player.set_Health(Player.get_Health());
        //                        }
        //                        else
        //                        {
        //                            cout << "\n You need " << Player.get_NextLvl() - Player.get_Experience() << " more experience to gain a level.\n";
        //                        }
        //                        Game_State.empty_MonsterCache();
        //                    }
        //                    else
        //                    {
        //                        Death();
        //                    }
        //                }
        //                else
        //                {
        //                    cout << "You do not see that monster here.";
        //                    return;
        //                }
        //            }
        //        }
        //        else if (option == 10)
        //        {
        //            Sleep(1500);
        //            Format.Paint(11, "\n You say: ", ""); cout << "\"" << command_2 << "\"" << endl;
        //            if (Game_State.get_MonsterCache()[0].get_Name() == "Merchant" || Game_State.get_MonsterCache()[0].get_Name() == "Villager" || Game_State.get_MonsterCache()[0].get_Name() == "Cityguard")
        //            {
        //                Format.Paint(11, "\n A ", ""); cout << Game_State.get_MonsterCache()[0].get_Name(); Format.Paint(11, " responds:", ""); Format.Paint(11, " Good day to you stranger!", "\n");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Format.Paint(12, "Invalid compound input ignored; please enter a valid command.", "\n");
        //    }
        //}
    }
}
