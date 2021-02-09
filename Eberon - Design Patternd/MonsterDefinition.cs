using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    abstract class MonsterDefinition
    {
        public abstract IMonster FactoryMethod();
        public Tuple<string,string> SpawnEnemy()
        {
            var enemy = FactoryMethod();
            if (enemy != null)
            {
                var enemyDetails = new Tuple<string, string>(enemy.Name(), enemy.Description());
                return enemyDetails;
            }
            else
            {
                return null;
            }
        }
    }
    class Monster
    {
        public void CreateMonster(MonsterDefinition creator)
        {
            ConsoleWriter.Write("\n A ", ConsoleColor.Green);
            ConsoleWriter.Write(creator.SpawnEnemy().Item1 + " ", ConsoleColor.White);
            ConsoleWriter.Write(creator.SpawnEnemy().Item2 + "\n", ConsoleColor.Green);
        }
        public void Encounter(int tile)
        {
            Random rng = new Random();
            int result = 0;
            switch (tile)
            {
                case 3:
                case 4:
                    CreateMonster(new SmallMonster());              
                    break;
                case 2:
                    result = rng.Next(1, 6);
                    if (result < 4) break;
                    CreateMonster(new SmallMonster());
                    break;
                case 6:
                case 9:
                    result = rng.Next(4, 9);
                    if (result < 7) break;
                    CreateMonster(new LargeMonster());
                    break;
                case 10:
                    result = rng.Next(5, 12);
                    if (result < 10) break;
                    CreateMonster(new LargeMonster());
                    break;
                case 13:
                    result = rng.Next(6, 15);
                    if (result < 13) break;
                    CreateMonster(new LargeMonster());
                    break;
            }
        }
    }
    class SmallMonster : MonsterDefinition
    {
        public override IMonster FactoryMethod()
        {
            Random rng = new Random();
            int random = rng.Next(1, 3);
            switch (random)
            {
                case 1:
                    return new Monster_Neko();
                case 2:
                    return new Monster_Mosquito();
                case 3:
                    return new Monster_Wolf();
                default:
                    return null;
            }
        }
    }

    class LargeMonster : MonsterDefinition
    {
        public override IMonster FactoryMethod()
        {
            Random rng = new Random();
            int random = rng.Next(1, 3);
            switch (random)
            {
                case 1:
                    return new Monster_Bear();
                case 2:
                    return new Monster_Footpad();
                case 3:
                    return new Monster_Golem();
                default:
                    return null;
            }
        }
    }

}
