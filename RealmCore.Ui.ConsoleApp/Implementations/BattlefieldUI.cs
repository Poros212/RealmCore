using RealmCore.Logic;
using RealmCore.Logic.Controls;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Validations;
using RealmCore.UI.ConsoleApp;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;

namespace RealmCore.UI.ConsoleApp.Implementations
{
    public class BattlefieldUI : IBattlefield
    {
        public BattleManager BattleManager { get; set; }

        public BattlefieldUI(BattleManager battleManager)
        {
            BattleManager = battleManager;
        }

        public void DisplayMap()
        {
            int currentRow = 0;

            foreach (Tile tile in BattleManager.CTX.BattleField.TileArray)
            {
                // If we've moved to a new row
                if (tile.XAxis != currentRow)
                {
                    Console.WriteLine(); // start a new line
                    currentRow = tile.XAxis;
                }
                if (tile.OccupyingPlayer == null)
                {
                    string color = tile.Terrain.Color;
                    AnsiConsole.Markup($" [{color}]{tile.Terrain.TerrainImage}[/] ");
                }
                else
                {
                    //if (tile.OccupyingPlayer == BattleManager.Player1)
                    //{
                    //    AnsiConsole.Markup($"[rapidblink cyan] P1 [/]");
                    //}
                    //else if (tile.OccupyingPlayer == BattleManager.Opponent1)
                    //{
                    //    AnsiConsole.Markup($"[rapidblink red] E1 [/]");
                    //}
                    if (tile.OccupyingPlayer != null && tile.OccupyingPlayer.typeFlag == "player")
                    {
                        AnsiConsole.Markup($"[rapidblink cyan] PL [/]");
                    }
                    else if (tile.OccupyingPlayer != null && tile.OccupyingPlayer.typeFlag == "enemy")
                    {
                        AnsiConsole.Markup($"[rapidblink red] EN [/]");
                    }
                }
            }
        }

        //public void DisplayMapWithSpell(string image, int x, int y)
        //{
        //    int currentRow = 0;

        //    foreach (Tile tile in BattleManager.CTX.BattleField.TileArray)
        //    {
        //        // If we've moved to a new row
        //        if (tile.XAxis != currentRow)
        //        {
        //            Console.WriteLine(); // start a new line
        //            currentRow = tile.XAxis;
        //        }
        //        if (tile.OccupyingPlayer != null)
        //        {
        //            if (tile.OccupyingPlayer == BattleManager.Player1)
        //            {
        //                AnsiConsole.Markup($"[rapidblink cyan] P1 [/]");
        //            }
        //            else if (tile.OccupyingPlayer == BattleManager.Opponent1)
        //            {
        //                AnsiConsole.Markup($"[rapidblink red] E1 [/]");
        //            }
        //        }
        //        else if (tile.XAxis == x && tile.YAxis == y)
        //        {
        //            AnsiConsole.Markup($" [yellow]{image}[/] ");
        //        }
        //        else if (tile.OccupyingPlayer == null)
        //        {
        //            string color = tile.Terrain.Color;
        //            AnsiConsole.Markup($" [{color}]{tile.Terrain.TerrainImage}[/] ");
        //        }
        //    }
        //}

        public string TryMove(Player player)
        {
            AnsiConsole.Clear();
            Console.WriteLine($"Movment Points: {player.ChosenCharacter.CurrentMovementPoints} / {player.ChosenCharacter.MaxMovementPoints}");
            Console.WriteLine();
            DisplayMap();
            DisplayBattleFieldLegend();
            Console.WriteLine("\n\nMovement Options:");
            Console.WriteLine($"{ControlMapping.MovementUP} - Move Up");
            Console.WriteLine($"{ControlMapping.MovementLEFT} - Move Left");
            Console.WriteLine($"{ControlMapping.MovementDOWN} - Move Down");
            Console.WriteLine($"{ControlMapping.MovementRIGHT} - Move Right");
            Console.WriteLine($"\n{ControlMapping.ExitMenu} - Exit Movement Menu");
            Console.Write("\nAction: ");
            return Console.ReadLine().ToLower();
        }

        public void ShowError(string message)
        {
            UiFormat.DisplayError(message);
        }

        public void DisplayBattleFieldLegend()
        {
            Console.WriteLine("\n\nBattlefield Legend:");
            var distinctTerrain = BattleManager.CTX.BattleField.TileArray
                .Cast<Tile>()
                .Select(t => t.Terrain)
                .DistinctBy(tr => tr.Name)
                .ToList();

            foreach (var terrain in distinctTerrain)
            {
                if (terrain.IsWalkable == true)
                {
                    Console.WriteLine($"{terrain.TerrainImage} = {terrain.Name} [movement cost: {terrain.MovementCost}]");
                }
                else
                {
                    Console.WriteLine($"{terrain.TerrainImage} = {terrain.Name} [Not Walkable]");
                }
            }
        }
    }
}