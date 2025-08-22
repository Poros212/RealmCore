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

        private Player? _occupyingPlayer; //TODO: Implement player occupying tile

        private bool _isOccupied;

        #endregion Fields

        #region Properties

        public int XAxis
        {
            get { return _xAxis; }
            set { _xAxis = value; }
        }

        public int YAxis
        {
            get { return _yAxis; }
            set { _yAxis = value; }
        }

        public Terrain Terrain
        {
            get { return _terrain; }
            set { _terrain = value; }
        }

        public bool IsOccupied
        {
            get { return _isOccupied; }
            set { _isOccupied = value; }
        }

        public Player OccupyingPlayer
        {
            get { return _occupyingPlayer; }
            set { _occupyingPlayer = value; }
        }

        #endregion Properties

        public Tile()
        {
            XAxis = 0;
            YAxis = 0;
            Terrain = new GrassTerrain(); // Default terrain type
            IsOccupied = false;
            OccupyingPlayer = null; // No player occupies the tile by default
        }

        public Tile(int x, int y)
        {
            XAxis = x;
            YAxis = y;
            Terrain = new Terrain();
            IsOccupied = false;
            OccupyingPlayer = null; // No player occupies the tile by default
        }
    }
}