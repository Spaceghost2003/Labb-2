using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        PlayIntro();
        splash();
        Console.ReadKey();
        soundtrack();
        var player = level.Elements
            .Where(p => p.GetType() == typeof(Player))
            .FirstOrDefault();
        List<string> messages = new();
        do
        {

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    player.Move(-1, 0, level.Elements);
                    break;
                case ConsoleKey.RightArrow:
                    player.Move(1, 0, level.Elements);
                    break;
                case ConsoleKey.UpArrow:
                    player.Move(0, -1, level.Elements);
                    break;
                case ConsoleKey.DownArrow:
                    player.Move(0, 1, level.Elements);
                    break;
                default:
                    break;
            }
            foreach (var element in level.Elements)
            {
                messages.AddRange(element.GetMessages());
                element.ResetMessages();
            }
            Console.Clear();

            foreach (LevelElement element in level.Elements)
            {
                element.Update(level.Elements);
                element.Draw(player);
            }
            Console.SetCursorPosition(1, 20);
            Console.WriteLine($"HP: {player.Health}");
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            messages.Clear();

            if (player.Health <= 0)
            {
                PlayIntro();
                DeathScreen();
                Console.ReadKey();
                break;
            }
        } while (true);
    }

//Fun things
public void splash()
    {
        Console.ForegroundColor = ConsoleColor.Red;           
        Console.WriteLine(@" 



                                  *              *        *         *
                    *         *                   *                   *                * 
           *              *              *              *                   *               *        *
                  
         ██▄ *   ▄      ▄     ▄▀  ▄███▄   ████▄    ▄       ▄█▄    █▄▄▄▄ ██     ▄ ▄   █     ▄███▄   █▄▄▄▄ 
         █  █  *  █      █  ▄▀    █▀   ▀  █   █     █      █▀ ▀▄  █  ▄▀ █ █   █   █  █     █▀   ▀  █  ▄▀ 
         █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █     █   ▀  █▀▀▌  █▄▄█ █ ▄   █ █     ██▄▄    █▀▀▌  
         █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █     █▄  ▄▀ █  █  █  █ █  █  █ ███▄  █▄   ▄▀ █  █  
         ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █     ▀███▀    █      █  █ █ █      ▀ ▀███▀     █   
         ▀▀▀         █   ██                     █   ██             ▀      █    ▀ ▀                  ▀    
                                                                  ▀                               
                                           PRESS ANY KEY TO BEGIN
                                         *                  *        *         *
                    *         *                     *                   *                * 
         *              *              *                 *                   *               *        *
              

                                         *                  *        *         *
                    *         *                     *                   *                * 
         *              *              *                 *                   *               *        *

 ");
        Console.ResetColor();
    }
public void DeathScreen()
{
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("____________________________________________________________________________________________________________");
        Console.WriteLine(@"
        

                                ▀▄    ▄ ████▄   ▄       ██▄   ▄█ ▄███▄   ██▄           
                                  █  █  █   █    █      █  █  ██ █▀   ▀  █  █          
                                   ▀█   █   █ █   █     █   █ ██ ██▄▄    █   █         
                                   █    ▀████ █   █     █  █  ▐█ █▄   ▄▀ █  █          
                                 ▄▀           █▄ ▄█     ███▀   ▐ ▀███▀   ███▀ ██ ██ ██ 


                                                                                  
                                                       
                  ");
        Console.WriteLine("____________________________________________________________________________________________________________");

        Thread.Sleep(100000);

    }

static void PlayIntro()
{
    SoundPlayer mainMenusond = new SoundPlayer("mainmenu.wav");
    mainMenusond.PlayLooping();
}

static void soundtrack()
    {
        SoundPlayer soundtrack = new SoundPlayer("soundtrack song.wav");
        soundtrack.PlayLooping();
    }
}


    

