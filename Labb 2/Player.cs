using System;
using System.Collections.Generic;
using System.Linq;
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
            Health = 10;
            Name = "Player";
        }
        public void MovePlayer()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key) 
            {
                case ConsoleKey.LeftArrow: 
                    X--;
                    break;
                case ConsoleKey.RightArrow :
                    X++;
                    break;
                case ConsoleKey.UpArrow:
                    Y++;
                    break;
                case ConsoleKey.DownArrow:
                    Y--;
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("spelet stängs");
                    break;


            }
        }

    }
}
