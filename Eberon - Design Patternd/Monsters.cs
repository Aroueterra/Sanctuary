using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    class Monster_Wolf : IMonster
    {
        public string Name()
        {
            return "Wolf";
        }
        public string Description()
        {
            return "is here, stalking you from the shadows of the evergreens.";
        }
    }
    class Monster_Mosquito : IMonster
    {
        public string Name()
        {
            return "Wolf";
        }
        public string Description()
        {
            return "is here, stalking you from the shadows of the evergreens.";
        }
    }
    class Monster_Neko : IMonster
    {
        public string Name()
        {
            return "Tabby Cat";
        }
        public string Description()
        {
            return "is here, affectionately rubbing against your feet.";
        }
    }
    class Monster_Bear : IMonster
    {
        public string Name()
        {
            return "Bear";
        }
        public string Description()
        {
            return "is sniffing around, looking for some honey.";
        }
    }
    class Monster_Footpad : IMonster
    {
        public string Name()
        {
            return "Footpad Trainee";
        }
        public string Description()
        {
            return "is skulking about, looking for a pocket to pick.";
        }
    }
    class Monster_Golem : IMonster
    {
        public string Name()
        {
            return "Golem";
        }
        public string Description()
        {
            return "lays here, deactivated and master-less.";
        }
    }
}
