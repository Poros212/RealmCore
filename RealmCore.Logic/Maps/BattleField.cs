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
        private int width = 10;
        private int height = 10;
        private Player _player;

        public Tile[,] TileArray
        {
            get { return _tileArray; }
            set { _tileArray = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public BattleField(Player player)
        {
            _tileArray = new Tile[10, 10];
            width = 10;
            height = 10;
            _player = player;
        }
    }
}