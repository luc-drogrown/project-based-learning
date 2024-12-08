// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using RLNET;

namespace RogueGame
{
    public class Game
    {
        //the screen height and width are in number of tiles
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;
        private static RLRootConsole _rootConsole;

        //the map console takes up most of the screen and is where the map will be drawn
        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        //below the map console is the message console for attack rolls and other info
        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        //the stat console is to the right of the map and display player and monster stats
        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        //above the map is the inventory console
        private static readonly int _inventoryWidth = 80;
        private static readonly int _inventoryHeight = 11;
        private static RLConsole _inventoryConsole;

        public static void Main()
        {
            string fontFileName = "terminal8x8.png";
            string consoleTitle = "Tutorial - Level 1";

            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);

            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);
            
            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;

            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate( object sender, UpdateEventArgs e )
        {
            //_rootConsole.Print(10,10, "It worked!", RLColor.White);

            //set the background color for each console
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, RLColor.Black);
            _mapConsole.Print(1, 1, "Map", RLColor.White);

            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, RLColor.Gray);
            _messageConsole.Print(1, 1, "Message", RLColor.White);

            _statConsole.SetBackColor(0,0, _statWidth, _statHeight, RLColor.Brown);
            _statConsole.Print(1, 1, "Stat", RLColor.White);

            _inventoryConsole.SetBackColor(0,0, _inventoryWidth, _inventoryHeight, RLColor.Cyan);
            _inventoryConsole.Print(1, 1, "Inventory", RLColor.White);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            //blit the subconsoles to the root console in the correct locations
            RLConsole.Blit(_mapConsole, 0,0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
            RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);

            //tell RLNET to draw the console that we set
            _rootConsole.Draw();
        }
    }
}