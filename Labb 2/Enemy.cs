using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract class Enemy : LevelElement
    {
        protected Enemy(int x, int y, char icon, ConsoleColor fColor) : base(x, y, icon, fColor)
        {
            
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefendDice { get; set; }
        public abstract void Update();


        
        
    }
}
