using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Maps
{
    public class Tile
    {
        #region Fields

        private int _xAxis;
        private int _yAxis;

        //terrain type
        //move cost
        private bool _isPassible;

        private bool _isOccupied;

        private char _tileImage;

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

        public bool IsPassible
        {
            get { return _isPassible; }
            set { _isPassible = value; }
        }

        public bool IsOccupied
        {
            get { return _isOccupied; }
            set { _isOccupied = value; }
        }

        public char TileImage
        {
            get { return _tileImage; }
            set { _tileImage = value; }
        }

        #endregion Properties

        public Tile()
        {
            XAxis = 0;
            YAxis = 0;
            IsPassible = true;
            IsOccupied = false;
            TileImage = '.';
        }

        public Tile(int x, int y, bool isPassible)
        {
            XAxis = x;
            YAxis = y;
            IsPassible = isPassible;
            IsOccupied = false;
            TileImage = '.';
        }
    }
}