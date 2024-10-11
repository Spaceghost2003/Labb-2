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
            base.Health = 10;
            base.Name = "Snake";
            base.AttackDice = new Dice(3,4,2);
            base.DefendDice = new Dice(1,8,5);
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
                    Math.Clamp(this.Y - player.Y, -1, 1),levelElements);
            }
        }
    }
}
