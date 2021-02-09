using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    class DemonRenderStrategy : IStrategy
    {
        public void RenderWorld(object data, object writer)
        {
            var world = data as int[,];
            var cw = writer as ConsoleWriter;
            cw.WriteMessage("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(", ConsoleColor.DarkBlue);
            cw.WriteMessage("  EBERON  ", ConsoleColor.Yellow);
            cw.WriteMessage(")~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]\n", ConsoleColor.DarkBlue);
            for (int y = 0, x = 0; y < 10;)
            {
                Console.Write(" ");
                //1=^,2=*,3=*,4=*,5=~,6=#,7=I,8=O,9='=',10=.,11=V'=',12=B~,13=DY'=',14=G-I,15=G'=',20=@
                switch (world[y, x])
                {
                    case 1:
                        cw.WriteMessage("^", ConsoleColor.White);
                        break;
                    case 2:
                        cw.WriteMessage("*", ConsoleColor.Black);
                        break;
                    case 3:
                        cw.WriteMessage("*", ConsoleColor.DarkGray);
                        break;
                    case 4:
                        cw.WriteMessage("*", ConsoleColor.DarkGray);
                        break;
                    case 5:
                        cw.WriteMessage("~", ConsoleColor.DarkRed);
                        break;
                    case 6:
                        cw.WriteMessage("#", ConsoleColor.White);
                        break;
                    case 7:
                        cw.WriteMessage("I", ConsoleColor.White);
                        break;
                    case 8:
                        cw.WriteMessage("O", ConsoleColor.White);
                        break;
                    case 9:
                        cw.WriteMessage("=", ConsoleColor.White);
                        break;
                    case 10:
                        cw.WriteMessage(".", ConsoleColor.DarkGray);
                        break;
                    case 11:
                        cw.WriteMessage("=", ConsoleColor.White);
                        break;
                    case 12:
                        cw.WriteMessage("~", ConsoleColor.Red);
                        break;
                    case 13:
                        cw.WriteMessage("=", ConsoleColor.DarkGray);
                        break;
                    case 14:
                        cw.WriteMessage("I", ConsoleColor.Gray);
                        break;
                    case 15:
                        cw.WriteMessage("=", ConsoleColor.DarkGray);
                        break;
                    case 20:
                        cw.WriteMessage("@", ConsoleColor.Magenta);
                        break;
                }
                x++;
                if (x == 40 && y != 10)
                {
                    y++;
                    Console.WriteLine("");
                    x = 0;
                }
            }
            cw.WriteMessage("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(", ConsoleColor.DarkBlue);
            cw.WriteMessage("  DARK WEST ", ConsoleColor.Yellow);
            cw.WriteMessage(")~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]\n", ConsoleColor.DarkBlue);
        }
    }
}
