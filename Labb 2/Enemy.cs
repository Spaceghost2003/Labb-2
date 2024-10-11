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


        public override void Update(List<LevelElement> levelelements)
        {
            switch (rnd.Next(0,15))
            {
                case 0:
                        base.Move(-1,0,levelelements);
                    break;
                case 1:
                        base.Move(1, 0,levelelements);
                    break;
                case 2:
                        base.Move(0, -1,levelelements);
                    break;
                case 3:
                        base.Move(0, 1,levelelements);
                    break;
                default:
                    break;
            }
        }



    }
}
