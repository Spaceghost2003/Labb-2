
using Labb_2;
using System.Runtime.CompilerServices;
LevelData level = new LevelData();
level.Load("Level1.txt");

Console.CursorVisible = false;
Player player = new Player(3, 4);
GameLoop gameloop = new GameLoop(level,player);

gameloop.RunLoop();


/*    foreach (LevelElement element in level.Elements)
    {
    element.Draw();
    }


Console.WriteLine();

*/