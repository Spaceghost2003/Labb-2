using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    internal class GameLoop 
    { 
        private LevelData leveldata;
        private Player player;


        public void RunLoop()
        {
            LevelData level = new LevelData();
            level.Load("Level1.txt");
            Player player = new Player(5, 3);
            while (true)
            {


                int x = 4;
                int y = 5;
                while (true)
                {
                    Console.Clear();
                    foreach (LevelElement element in level.Elements)
                    {
                        element.Draw();
                    }

                    player.DrawPlayer();
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    Console.SetCursorPosition(x, y);
                    Console.Write('@');
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (!level.Collision(player.X - 1, player.Y))
                            {
                                player.Move(-1, 0);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (!level.Collision(player.X + 1, player.Y))
                            {
                                player.Move(1, 0);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (!level.Collision(player.X, player.Y - 1))
                            {
                                player.Move(0, -1);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (!level.Collision(player.X, player.Y + 1))
                            {
                                player.Move(0, 1);
                            }
                            break;
                    }
                }
            }


        }




    }


        
    
}
