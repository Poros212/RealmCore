using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Tiles.Terrains
{
    public class GrassTerrain : Terrain
    {
        public GrassTerrain()
        {
            Name = "Grass";
            Description = "A patch of grass";
            IsWalkable = true;
            MovementCost = 1;
            TerrainImage = " . ";
        }
    }
}