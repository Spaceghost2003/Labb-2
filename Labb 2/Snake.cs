using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class Snake:Enemy
    {

        public Snake(int x, int y) : base(x,y,'s',ConsoleColor.Green)
        {
            Health = 25;
            Name = "Snake";
        }
        public override void Update(List<LevelElement> levelElements)
        {


        }

        public override void Move(int moveX, int moveY)
        {
            X += moveX;
            Y += moveY;

        }
    }
}
