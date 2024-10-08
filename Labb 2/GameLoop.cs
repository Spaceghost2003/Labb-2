using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class GameLoop 
    { 
        private LevelData leveldata;
        private Player player;
        public GameLoop(LevelData ldata, Player player)
        {
            this.leveldata = ldata;
            this.player = player;
        }

        /*  List<Enemy> enemies = LevelData.Elements.OfType<Enemy>().ToList;*/


            public void RunLoop() 
            {
            
            }
    }
}
