using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class Rat : Enemy
    {
        Random rnd = new Random();
        public Rat(int x, int y) :base(x,y,'r',ConsoleColor.Red)
        {
            Health = 10;
            Name = "Rat";
        }
       public override void Update()
        {
            throw new NotImplementedException();
        }

        public void DrawRat()
        {
            X = rnd.Next(1, 4);
            Y = rnd.Next(1, 4);
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Icon);
        }
    }
}
