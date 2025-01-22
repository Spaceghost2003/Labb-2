using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Labb_2
{
    public class LevelData
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
        private List<LevelElement> _elements;
		public List<LevelElement> Elements
		{
			get { return _elements; }
			set { _elements = value; }
		}
		public int xPosition=1;
		public int yPosition=0;
		public char unit;
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

		public void LoadFromSave()
		{

		}
    }
}
