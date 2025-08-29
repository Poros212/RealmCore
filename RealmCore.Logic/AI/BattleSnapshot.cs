using RealmCore.Logic.Battle;
using RealmCore.Logic.Maps;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public class BattleSnapshot
    {
        public IImmutableList<Player> Players { get; }
        public IImmutableList<Enemy> Enemies { get; }
        public Tiles.Tile[,] TileArray { get; }
        public int Width { get; }
        public int Height { get; }

        public BattleSnapshot
            (
                IImmutableList<Player> players,
                IImmutableList<Enemy> enemies,
                Tiles.Tile[,] tileArray,
                int width,
                int height
            )
        {
            Players = players;
            Enemies = enemies;
            TileArray = tileArray;
            Width = width;
            Height = height;
        }
    }
}