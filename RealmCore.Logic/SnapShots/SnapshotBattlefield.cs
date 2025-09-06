using RealmCore.Logic.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotBattlefield
    {
        public SnapshotTile[,] TileArray { get; }
        public int Width { get; }
        public int Height { get; }
        public IReadOnlyDictionary<Guid, (int, int)> Actors { get; }

        public SnapshotBattlefield(int width, int height, SnapshotTile[,] tileArray, IReadOnlyDictionary<Guid, (int, int)> actors)
        {
            Width = width;
            Height = height;
            TileArray = tileArray;
            Actors = actors;
        }
    }
}