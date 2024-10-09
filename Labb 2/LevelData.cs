using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace Labb_2
{
    internal class LevelData
    {
        private List<LevelElement> _elements;

	
		    public int xPosition=1;
			public int yPosition=0;
		    public char unit;


		public List<LevelElement> Elements
		{
			get { return _elements; }
		}
		public void Load(string filename) 
		{
			using(StreamReader reader = new StreamReader(filename))
			{
			_elements = new List<LevelElement>();
				while (!reader.EndOfStream)
				{
                    unit = (char)reader.Read();

					switch (unit) 
					{
						case '#':
							_elements.Add(new Wall(xPosition, yPosition));
							break;
						case 'r':
							_elements.Add(new Rat(xPosition, yPosition));
							break;
						case 's':
							_elements.Add(new Snake(xPosition, yPosition));
							break;
						case '@':
							_elements.Add(new Player(xPosition, yPosition));
							break;
						case '\n':
                            yPosition++;
                            xPosition = 0;
							break;
                    }
					xPosition++;
				}

			}

        }
		public bool Collision(int x, int y)
		{
			foreach (var element in _elements)
			{
				if(element.X == x && element.Y == y && element is Wall)
				{
					return true;
				}if (element.X == x && element.Y == y && element is Rat)
				{
					return true;
				}if(element.X == x && element.Y == y && element is Snake)
				{
					return true;
				}

			}
			return false;
		}



    }
}
