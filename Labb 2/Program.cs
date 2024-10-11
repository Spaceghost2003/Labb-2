
using Labb_2;
using System.Media;
using System.Runtime.CompilerServices;


/*LevelData level = new LevelData();
level.Load("Level1.txt");
*/
Console.CursorVisible = false;
GameLoop gameloop = new GameLoop();
/*gameloop.Load();*/
gameloop.RunLoop();



/*while (true)
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
                if(!level.Collision(player.X - 1, player.Y))
                {
                player.Move(-1, 0);
                }
                break;
            case ConsoleKey.RightArrow:
                if(!level.Collision(player.X + 1, player.Y))
                {
                player.Move(1, 0);
                }
                break;
            case ConsoleKey.UpArrow:
                if(!level.Collision(player.X, player.Y - 1))
                {
                player.Move(0, -1);
                }
                break;
            case ConsoleKey.DownArrow:
                if(!level.Collision(player.X, player.Y+1))
                {
                player.Move(0, 1);
                }
                break;
        }
    }
}*/


/*    foreach (LevelElement element in level.Elements)
    {
    element.Draw();
    }


Console.WriteLine();

*/