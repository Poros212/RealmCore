using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Tiles.Terrains
{
    public class WallTerrain : Terrain
    {
        public WallTerrain()
        {
            Name = "Wall";
            Description = "A solid wall that blocks movement";
            IsWalkable = false;
            MovementCost = 0;
            TerrainImage = "##";
            Color = "grey";
        }
    }
}