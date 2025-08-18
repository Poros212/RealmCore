using RealmCore.Logic.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Tiles;
using RealmCore.Logic;
using RealmCore.Logic.Managers;

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
                    Console.Write($"  P  ");
                }
            }
        }
    }
}