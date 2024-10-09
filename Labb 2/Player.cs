using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class Player: LevelElement
    {
        public Dice AttackDice { get; set; }
        public Dice DefendDice { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Player(int x, int y) : base(x,y,'@', ConsoleColor.Green)
        {
            x = X;
            y = Y;
            Health = 10;
            Name = "Player";
        }



        public override void Move(int moveX, int moveY)
        {
                X += moveX;
                Y += moveY;

        }
        

       
    }
}
