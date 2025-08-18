using RealmCore.Logic;
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
            Console.Clear();
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

        public void UpdateMapMovement()
        {
            while (true)
            {
                DisplayMap();
                Console.Write("move: ");
                string tmp = Console.ReadLine();
                ValidationResultDto<string> movementResult = BattleManager.PlayerMovement(tmp);
                if (movementResult.IsOK == false)
                {
                    UiFormat.DisplayError(movementResult.ErrorMessage);
                    continue;
                }
                //DisplayMap();
                //break;
            }
        }

        public void DisplayBattleFieldLegend()
        {
            DisplayMap();

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

            Console.WriteLine();
            UiFormat.UiPressAnyKey();
        }
    }
}