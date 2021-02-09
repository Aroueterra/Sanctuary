using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    public class WorldRenderer
    {
        // The Context maintains a reference to one of the Strategy objects. The
        // Context does not know the concrete class of a strategy. It should
        // work with all strategies via the Strategy interface.
        private IStrategy _strategy;
        private int Current_Strategy = 1;
        public WorldRenderer()
        { }

        // Usually, the Context accepts a strategy through the constructor, but
        // also provides a setter to change it at runtime.
        public WorldRenderer(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy(IStrategy strategy, int setting)
        {
            this._strategy = strategy;
            this.Current_Strategy = setting;
        }

        public int GetStrategy()
        {
            return this.Current_Strategy;
        }

        public void Render(int ordinate_y, int ordinate_x)
        {
            if (World.Replaced_Counter > 0)
            {
                for (int y = 0, x = 0; y < 10;)
                {
                    if (World.Instance.GetWorld()[y, x] == 20)
                        World.Instance.GetWorld()[y, x] = World.Replaced_Tile;
                    x++;
                    if (x == 40 && y != 10)
                    {
                        y++;
                        Console.WriteLine();
                        x = 0;
                    }
                }
            }
            else
            {
                World.Replaced_Counter++;
            }
            World.Replaced_Tile = World.Instance.GetWorld()[ordinate_y, ordinate_x];
            World.Instance.GetWorld()[ordinate_y, ordinate_x] = 20;
            if (Current_Strategy == 1) { SetStrategy(new BasicRenderStrategy(),1); } else { SetStrategy(new DemonRenderStrategy(),2); }
            this._strategy.RenderWorld(World.Instance.GetWorld(), new ConsoleWriter());
            
            Player.Instance.DisplayAttributes();
        }

    }
}
