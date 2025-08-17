using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Maps
{
    public class BattleField
    {
        private Tile[,] _tileSet;
        private int width = 10;
        private int height = 10;

        public Tile[,] TileSet
        {
            get { return _tileSet; }
            set { _tileSet = value; }
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

        public BattleField()
        {
            _tileSet = new Tile[10, 10];
            width = 10;
            height = 10;
        }

        public void InitializeTiles()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    _tileSet[row, col] = new Tile(row, col, true);
                }
            }
        }
    }
}