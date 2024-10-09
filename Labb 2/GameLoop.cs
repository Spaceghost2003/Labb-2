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
                element.Draw();
            }
            player.Draw();

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (!player.Collision(player.X - 1, player.Y,level.Elements))
                    {
                        player.Move(-1, 0);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!player.Collision(player.X + 1, player.Y,level.Elements))
                    {
                        player.Move(1, 0);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (!player.Collision(player.X, player.Y - 1,level.Elements))
                    {
                        player.Move(0, -1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (!player.Collision(player.X, player.Y + 1,level.Elements))
                    {
                        player.Move(0, 1);
                    }
                    break;
            }
        }
    }
}


    

