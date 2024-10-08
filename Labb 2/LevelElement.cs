using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected char Icon { get; set; }
        protected ConsoleColor FColor { get; set; }
        public LevelElement(int x, int y, char icon,ConsoleColor fColor)
        {
            X = x;
            Y = y;
            Icon = icon;
            FColor = fColor;
            
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = FColor;
            Console.WriteLine(Icon);
            Console.ResetColor();
            
        }

    }
}
    

