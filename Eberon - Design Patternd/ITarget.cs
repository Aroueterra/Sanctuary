using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    interface ITarget
    {
        void GetScore();
    }
    class PlayerAdapter : ITarget
    {
        private readonly Player _adaptee;

        public PlayerAdapter(Player instance)
        {
            this._adaptee = instance;
        }

        public void GetScore()
        {
            var cw = new ConsoleWriter();
            cw.WriteMessage($"\n ['{this._adaptee.GetName()}']", ConsoleColor.Yellow); cw.WriteMessage($", A level '{this._adaptee.GetLevel()}' adventurer \n", ConsoleColor.White);
            cw.WriteMessage($"You have '{this._adaptee.GetHealth()}' health, of which '{this._adaptee.GetCurrentHealth()}' is remaining, \n", ConsoleColor.White);
            cw.WriteMessage($"You have '{this._adaptee.GetMana()}' remaining mana. \n", ConsoleColor.White);
            cw.WriteMessage($"You have '{this._adaptee.GetGold()}' gold.\n", ConsoleColor.White);
            cw.WriteMessage($"You have '{this._adaptee.GetExp()}' experience.\n", ConsoleColor.White);
        }
    }
}
