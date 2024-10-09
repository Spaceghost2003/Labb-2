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
            var player = levelElements
                .Where(e => e.GetType() == typeof(Player))
                .FirstOrDefault();

            var range = Math.Sqrt((this.X - player.X) * (this.X - player.X) +
                (this.Y - player.Y) * (this.Y - player.Y)) ;

            if(range <= 2)
            {
                Move(Math.Clamp(this.X - player.X, -1, 1),
                    Math.Clamp(this.Y - player.Y, -1, 1));
            }


        }

        public override void Move(int moveX, int moveY)
        {
            X += moveX;
            Y += moveY;

        }
    }
}
