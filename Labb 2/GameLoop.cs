using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2;

internal class GameLoop 
{

    private Player player;
    public LevelData level = new LevelData();

    public GameLoop()
    {
        Load();
    }
    public void Load()
    {
        level.Load("Level1.txt");

    }
    public void RunLoop()
    {
        var player = level.Elements
            .Where(p => p.GetType() == typeof(Player))
            .FirstOrDefault();

        while (true)
        {
            Console.Clear();
            foreach (LevelElement element in level.Elements)
            {
                
                element.Update(level.Elements);
                element.Draw(player);
            }
            player.Draw(player);

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                        player.Move(-1, 0,level.Elements);
                    break;
                case ConsoleKey.RightArrow:
                        player.Move(1, 0,level.Elements);
                    break;
                case ConsoleKey.UpArrow:
                        player.Move(0, -1,level.Elements);
                    break;
                case ConsoleKey.DownArrow:
                        player.Move(0, 1,level.Elements);
                    break;
            }
        }
    }
}


    

