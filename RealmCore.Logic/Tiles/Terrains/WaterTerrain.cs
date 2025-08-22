using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Tiles.Terrains
{
    public class WaterTerrain : Terrain
    {
        public WaterTerrain()
        {
            Name = "Water";
            Description = "A shallow pool of water";
            IsWalkable = true;
            MovementCost = 2;
            TerrainImage = "~~";
            Color = "blue";
        }
    }
}