using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Tiles
{
    public class Tile
    {
        #region Fields

        private int _xAxis;

        private int _yAxis;

        private Terrain _terrain;

        private Player? _occupyingPlayer;

        #endregion Fields

        #region Properties

        public int XAxis
        {
            get { return _xAxis; }
        }

        public int YAxis
        {
            get { return _yAxis; }
        }

        public Terrain Terrain
        {
            get { return _terrain; }
            set { _terrain = value; }
        }

        public Player? OccupyingPlayer
        {
            get { return _occupyingPlayer; }
            internal set { _occupyingPlayer = value; }
        }

        #endregion Properties

        public Tile(int x, int y)
        {
            _xAxis = x;
            _yAxis = y;
            Terrain = new GrassTerrain();
            OccupyingPlayer = null; // No player occupies the tile by default
        }
    }
}