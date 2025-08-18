using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Tiles.Terrains
{
    public class Terrain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MovementCost { get; set; }
        public bool IsWalkable { get; set; }
        public string TerrainImage { get; set; }

        public Terrain()
        {
            Name = "Default Terrain";
            Description = "This is a default terrain type.";
            MovementCost = 1;
            IsWalkable = true;
            TerrainImage = " # ";
        }
    }
}