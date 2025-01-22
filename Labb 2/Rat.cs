using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class Rat : Enemy
    {
        public Rat(int x, int y) :base(x,y,'r',ConsoleColor.Red)
        {
            base.Health = 10;
            base.Name = "Rat";
            base.AttackDice = new Dice(1, 6, 3);
            base.DefendDice = new Dice(1, 6, 1);
        }
    }
}
