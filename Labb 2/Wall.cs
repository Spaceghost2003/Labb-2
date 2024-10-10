using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
     internal class Wall:LevelElement
    {
        
        public Wall(int x, int y) : base(x, y, '#', ConsoleColor.Gray)
        {
            base.Health = 10000;
            base.AttackDice = new Dice(0,0,0);
            base.DefendDice = new Dice(0,0,0);
        }

    }
}
