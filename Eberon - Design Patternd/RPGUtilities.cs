using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    class RPGUtilities
    {
        public List<string> Split(string input)
        {
            List<string> result;
            result = input.Split(' ').ToList();
            return result;
        }
        public int CheckMove(int Move)
        {
            var cw = new ConsoleWriter();
            switch (Move)
            {
                case 1:
                    cw.WriteMessage("The mountain looks difficult to climb, you choose to go elsewhere.\n", ConsoleColor.DarkRed);
                    return 0;
                case 5:
                case 12:
                    cw.WriteMessage("There is a body of water blocking your path.\n", ConsoleColor.DarkRed);
                    return 0;
                case 7:
                case 14:
                    cw.WriteMessage("The building walls block your path.\n", ConsoleColor.DarkRed);
                    return 0;
                case 13:
                    cw.WriteMessage("You cannot enter this way.\n", ConsoleColor.DarkRed);
                    return 0;
            }
            return 1;
        }
        public int ExecuteCommand(string command)
        {
            var commands = new Dictionary<string, int>
            {
                ["north"] = 1,
                ["n"] = 1,
                ["east"] = 2,
                ["e"] = 2,
                ["south"] = 3,
                ["s"] = 3,
                ["west"] = 4,
                ["w"] = 4,
                ["look"] = 5,
                ["help"] = 6,
                ["heal"] = 7,
                ["get"] = 8,
                ["kill"] = 9,
                ["say"] = 10,
                ["shift"] = 11,
                ["score"] = 12,
            };
            int value;
            bool found = commands.TryGetValue(command, out value);
            if (!found)
            {
                value = 0;
            }
            return value;
        }
        public void HelpMenu()
        {
            IEnumerable<Tuple<string, string, string>> authors =
            new[]
            {
                Tuple.Create("north", "Go North", "[north],[n]"),
                Tuple.Create("east", "Go East", "[east],[e]"),
                Tuple.Create("south", "Go South", "[south],[s]"),
                Tuple.Create("west", "Go West", "[west],[w]"),
                Tuple.Create("kill", "Initiates combat with target", "[kill]_[target]"),
                Tuple.Create("look", "Pulls a description of your location", "[look]"),
                Tuple.Create("shift", "Enter a trance state", "[shift]"),
                Tuple.Create("score", "Check your status", "[score] [sc]"),
            };

            Console.WriteLine(authors.ToStringTable(
              new[] { "Command", "Description", "Syntax" },
              a => a.Item1, a => a.Item2, a => a.Item3));
        }
    }
    
}
