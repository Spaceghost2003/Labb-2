﻿using System;
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
        public Rat(int x, int y) :base(x,y,'r',ConsoleColor.Red)
        {
            Health = 10;
            Name = "Rat";
        }
       public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
