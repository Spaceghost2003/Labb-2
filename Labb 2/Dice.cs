using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    public class Dice
    {
        private int _sides   { get; set; }
        private int _amount { get; set; }
        public int _modifier { get; set; }

        public Dice(int numberOfDice, int sidesPerDice, int Modifier)
        {
            _amount = numberOfDice;
            _sides =  sidesPerDice;
            _modifier = Modifier;
        }
        public int ThrowDice() 
        {
            Random rnd = new Random();
            int total=0;
            for (int i = 0; i < _amount; i++)
            {
                total += rnd.Next(1, _sides + 1);
            }
            return total + _modifier;
        }

        public override string ToString()
        {
            return $"{_amount}d{_sides}+{_modifier}";
        }


    }
}
