using RealmCore.Logic;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Maps;
using RealmCore.UI.ConsoleApp.Implementations;

namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //IPlayerCreationUI playerCreationUI = new PlayerCreationConsoleUI();

            //PlayerCreationManager playerCreationManager = new PlayerCreationManager(playerCreationUI);

            //Player playerCharacter = playerCreationManager.CreatePlayer();

            //Console.WriteLine($"Welcome {playerCharacter.Name}, you have chosen the {playerCharacter.ChosenCharacter.Name} class.");

            //Console.WriteLine("REALMCORE");
            //Console.WriteLine("New Game");
            //Console.WriteLine("Continue");

            BattleField battlefield = new BattleField();

            battlefield.InitializeTiles();

            //foreach (var tile in battlefield.TileSet)
            //{
            //    if (tile.XAxis == 0)
            //    {
            //        Console.Write($"[{tile.XAxis},{tile.YAxis}]");
            //        continue;
            //    }
            //}
            //Console.WriteLine();
            //foreach (var tile in battlefield.TileSet)
            //{
            //    if (tile.XAxis == 1)
            //    {
            //        Console.Write($"[{tile.XAxis},{tile.YAxis}]");
            //        continue;
            //    }
            //}
            //Console.WriteLine();
            //foreach (var tile in battlefield.TileSet)
            //{
            //    if (tile.XAxis == 3)
            //    {
            //        Console.Write($"[{tile.XAxis},{tile.YAxis}]");
            //        continue;
            //    }
            //}
            //Console.WriteLine();
            //foreach (var tile in battlefield.TileSet)
            //{
            //    if (tile.XAxis == 4)
            //    {
            //        Console.Write($"[{tile.XAxis},{tile.YAxis}]");
            //        continue;
            //    }
            //}

            //for (int x = 0; x < battlefield.Width; x++)   // rows
            //{
            //    for (int y = 0; y < battlefield.Height; y++)  // columns
            //    {
            //        Console.Write($"[{}]");
            //    }

            //    // After finishing this row, drop to next line
            //    Console.WriteLine();
            //}

            //foreach (Tile tile in battlefield.TileSet)
            //{
            //}

            int currentRow = 0;

            foreach (Tile tile in battlefield.TileSet)
            {
                // If we've moved to a new row
                if (tile.XAxis != currentRow)
                {
                    Console.WriteLine(); // start a new line
                    currentRow = tile.XAxis;
                }

                Console.Write($"[{tile.XAxis}{tile.TileImage}{tile.YAxis}]");
            }

            Console.ReadKey();
        }
    }
}