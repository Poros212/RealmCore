using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Tiles;

namespace RealmCore.Logic.Maps
{
    public class BattleField
    {
        private Tile[,] _tileArray;
        private int _width = 15;
        private int _height = 15;
        private Player _player;

        public Tile[,] TileArray
        {
            get { return _tileArray; }
            set { _tileArray = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public BattleField(Player player, int height, int width)
        {
            Height = height;
            Width = width;
            TileArray = new Tile[Height, Width];
            Player = player;
        }
    }
}