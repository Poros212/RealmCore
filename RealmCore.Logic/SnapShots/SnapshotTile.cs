using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotTile
    {
        public int XAxis { get; }
        public int YAxis { get; }
        public SnapshotTerrain Terrain { get; }
        public Guid? OccupyingPlayerId { get; }

        public SnapshotTile(int x, int y, SnapshotTerrain terrain, Guid? occupyingPlayerId)
        {
            XAxis = x;
            YAxis = y;
            Terrain = terrain;
            OccupyingPlayerId = occupyingPlayerId;
        }
    }
}