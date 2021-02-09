using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    public class ConsoleWriter
    {
        private static object _MessageLock = new object();
        public void WriteMessage(string message, ConsoleColor rgb)
        {
            lock (_MessageLock)
            {
                Console.ForegroundColor = rgb;
                Console.Write(message);
                Console.ResetColor();
            }
        }
        public static void Write(string message, ConsoleColor rgb)
        {
            lock (_MessageLock)
            {
                Console.ForegroundColor = rgb;
                Console.Write(message);
                Console.ResetColor();
            }
        }
    }
}
