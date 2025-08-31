using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotTerrain
    {
        public string Name { get; }
        public string Description { get; }
        public int MovementCost { get; }
        public bool IsWalkable { get; }
        public string TerrainImage { get; }
        public string? Color { get; }

        public SnapshotTerrain(string name, string description, int movementCost, bool isWalkable, string terrainImage, string? color)
        {
            Name = name;
            Description = description;
            MovementCost = movementCost;
            IsWalkable = isWalkable;
            TerrainImage = terrainImage;
            Color = color;
        }
    }
}