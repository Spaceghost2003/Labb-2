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
        public string Name { get; set; }
/*        public int Health { get; set; }*/
        public Player(int x, int y) : base(x,y,'@', ConsoleColor.Green)
        {
            x = X;
            y = Y;
            Health = 100;
            Name = "Player";
            base.AttackDice = new Dice(2,6,2);
            base.DefendDice = new Dice(2,6,0);
        }



        

       
    }
}
