using RealmCore.Logic;
using RealmCore.Logic.Controls;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.UI.ConsoleApp.Map
{
    public class BattlefieldUI
    {
        public BattleManager BattleManager { get; set; }

        public BattlefieldUI(BattleManager battleManager)
        {
            BattleManager = battleManager;
        }

        public void DisplayMap()
        {
            int currentRow = 0;

            foreach (Tile tile in BattleManager.BattleField.TileArray)
            {
                // If we've moved to a new row
                if (tile.XAxis != currentRow)
                {
                    Console.WriteLine(); // start a new line
                    currentRow = tile.XAxis;
                }
                if (tile.OccupyingPlayer == null)
                {
                    Console.Write($" {tile.Terrain.TerrainImage} ");
                }
                else
                {
                    Console.Write($" P1 ");
                }
            }
        }

        public void MovementMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Movment Points: {BattleManager.Player.ChosenCharacter.CurrentMovementPoints} / {BattleManager.Player.ChosenCharacter.MaxMovementPoints}");
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
                string tmp = Console.ReadLine().ToLower();
                ValidationResultDto<string> movementResult = BattleManager.PlayerMovement(tmp);
                if (movementResult.IsOK == false)
                {
                    if (movementResult.ErrorMessage == "exit")
                    {
                        Console.Clear();
                        return; // Exit the movement menu
                    }
                    UiFormat.DisplayError(movementResult.ErrorMessage);
                    continue;
                }
            }
        }

        public void DisplayBattleFieldLegend()
        {
            Console.WriteLine("\n\nBattlefield Legend:");
            var distinctTerrain = BattleManager.BattleField.TileArray
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