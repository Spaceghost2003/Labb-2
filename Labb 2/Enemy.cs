using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb_2
{
    abstract class Enemy : LevelElement
    {
        protected Enemy(int x, int y, char icon, ConsoleColor fColor) : base(x, y, icon, fColor)
        {
            
        }
        public Random rnd = new Random();
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefendDice { get; set; }
        public override void Update(List<LevelElement> levelelements)
        {
            switch (rnd.Next(0,4))
            {
                case 0:
                    if(!base.Collision(this.X-1,this.Y,levelelements))
                        base.Move(-1,0);
                    break;
                case 1:
                    if (!base.Collision(this.X+1 , this.Y, levelelements))
                        base.Move(1, 0);
                    break;
                case 2:
                    if(!base.Collision(this.X, this.Y-1, levelelements))
                        base.Move(0, -1);
                    break;
                case 3:
                    if (!base.Collision(this.X, this.Y+1, levelelements))
                        base.Move(0, 1);
                    break;
                default:
                    break;
            }

        }


        
        
    }
}
