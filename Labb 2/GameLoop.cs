using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;


namespace Labb_2;

internal class GameLoop 
{
    public DungeonDataAccess db = new DungeonDataAccess();
    public Player player;
    public LevelData level = new LevelData();
    bool startNewGame = true;
    public GameLoop()
    {
        //splash();
        //Load();
        ShowMainMenu();
    }
    public void Load()
    {
        level.Load("Level1.txt");

    }
 
    public async void RunLoop()
    {
        
        Console.ReadKey();
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
                case ConsoleKey.P:
                    SaveGame();
                    break;
                case ConsoleKey.L:
                    level.Elements = db.LoadSave();
                    player = level.Elements
                    .Where(p => p.GetType() == typeof(Player))
                    .FirstOrDefault();
                    break;

                default:
                    break;
            }
            foreach (var element in level.Elements.Where(e => e != null))
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
                
                DeathScreen();
                Console.ReadKey();
                break;
            }
        } while (true);
    }


    public void SaveGame()
    {
        var dbHelper = new DungeonDataAccess();
         dbHelper.CreateSave(level.Elements);
    }


//Fun things
public void splash()
    {

        string newGame = @" 

        

          
                  
         ██▄ *   ▄      ▄     ▄▀  ▄███▄   ████▄    ▄       ▄█▄    █▄▄▄▄ ██     ▄ ▄   █     ▄███▄   █▄▄▄▄ 
         █  █  *  █      █  ▄▀    █▀   ▀  █   █     █      █▀ ▀▄  █  ▄▀ █ █   █   █  █     █▀   ▀  █  ▄▀ 
         █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █     █   ▀  █▀▀▌  █▄▄█ █ ▄   █ █     ██▄▄    █▀▀▌  
         █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █     █▄  ▄▀ █  █  █  █ █  █  █ ███▄  █▄   ▄▀ █  █  
         ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █     ▀███▀    █      █  █ █ █      ▀ ▀███▀     █   
         ▀▀▀         █   ██                     █   ██             ▀      █    ▀ ▀                  ▀    
                                                                  ▀                               
                            
            
         Controls: press P to save, press L to load
        ";
        bool startgame=false;
        string oldGame=
        @" 

        

          
                  
         ██▄ *   ▄      ▄     ▄▀  ▄███▄   ████▄    ▄       ▄█▄    █▄▄▄▄ ██     ▄ ▄   █     ▄███▄   █▄▄▄▄ 
         █  █  *  █      █  ▄▀    █▀   ▀  █   █     █      █▀ ▀▄  █  ▄▀ █ █   █   █  █     █▀   ▀  █  ▄▀ 
         █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █     █   ▀  █▀▀▌  █▄▄█ █ ▄   █ █     ██▄▄    █▀▀▌  
         █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █     █▄  ▄▀ █  █  █  █ █  █  █ ███▄  █▄   ▄▀ █  █  
         ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █     ▀███▀    █      █  █ █ █      ▀ ▀███▀     █   
         ▀▀▀         █   ██                     █   ██             ▀      █    ▀ ▀                  ▀    
                                                                  ▀                               
                                                     NEW GAME  
                                                    >CONTINUE
 

        ";
        int[] ints;

        Console.ForegroundColor = ConsoleColor.Red;
        ConsoleKeyInfo input = Console.ReadKey(true);
        
        
        startNewGame = true;
        do
        {
            switch (input.Key)
            {
                case (ConsoleKey.UpArrow):
                    Console.WriteLine(newGame);
                    startNewGame = true;
                    if (input.Key == ConsoleKey.Enter)
                    {
                        level.Load("Level1.txt");
                        startgame = true;
                    }
                    break;
                case (ConsoleKey.DownArrow):
                    Console.WriteLine(oldGame);
                    if (input.Key == ConsoleKey.Enter)
                    {
                        level.Elements = db.LoadSave();
                        startgame = false;
                    }
                    break;
            }
        } while (startgame == false);
        Console.ResetColor();
    }


    public void ShowMainMenu()
    {
        string[] menuOptions = { "New Game", "Continue" };
        int selectedOption = 0;

        while (true)
        {
            Console.Clear();

            
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedOption)
                {
                //Console.WriteLine("  ██▄ *   ▄      ▄     ▄▀  ▄███▄   ████▄    ▄       ▄█▄    █▄▄▄▄ ██     ▄ ▄   █     ▄███▄   █▄▄▄▄ \r\n         █  █  *  █      █  ▄▀    █▀   ▀  █   █     █      █▀ ▀▄  █  ▄▀ █ █   █   █  █     █▀   ▀  █  ▄▀ \r\n         █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █     █   ▀  █▀▀▌  █▄▄█ █ ▄   █ █     ██▄▄    █▀▀▌  \r\n         █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █     █▄  ▄▀ █  █  █  █ █  █  █ ███▄  █▄   ▄▀ █  █  \r\n         ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █     ▀███▀    █      █  █ █ █      ▀ ▀███▀     █   \r\n         ▀▀▀         █   ██                     █   ██             ▀      █    ▀ ▀                  ▀   \n");
                    
                    
                    Console.WriteLine($" " +
                        $"" +
                        $"" + 
                        $"" +
                        $"" +
                        $"\n" +
                        $"\n> {menuOptions[i]}");
                }
                else
                {
                    Console.WriteLine($"\n \n  {menuOptions[i]}");
                }
            }

            
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow) 
            {
                selectedOption = (selectedOption - 1 + menuOptions.Length) % menuOptions.Length;
            }
            else if (key == ConsoleKey.DownArrow) 
            {
                selectedOption = (selectedOption + 1) % menuOptions.Length;
            }
            else if (key == ConsoleKey.Enter) 
            {
                Console.Clear();
                if (selectedOption == 0)
                {
                    Console.WriteLine("New game...");
                    level.Load("Level1.txt");
                    break; 
                }
                else if (selectedOption == 1)
                {
                    Console.WriteLine("Continuing...");
                    level.Elements = db.LoadSave();
                    break;
                }
            }
        }
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


}


    

