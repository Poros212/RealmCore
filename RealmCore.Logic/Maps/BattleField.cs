using RealmCore.Logic.Battle;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Maps
{
    public class BattleField
    {
        private Tile[,] _tileArray;
        private readonly int _width = 15;
        private readonly int _height = 15;
        private readonly Dictionary<Guid, (int, int)> _actors = new();

        public Tile[,] TileArray
        {
            get { return _tileArray; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public BattleField(int xWidth, int yHeight)
        {
            _height = yHeight;
            _width = xWidth;
            _tileArray = new Tile[Width, Height];
            InitializeTiles();
        }

        public void InitializeTiles()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    TileArray[col, row] = new Tile(col, row);
                }
            }
        }

        #region Queries (read only)

        public bool InBounds(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTileOccupied(int x, int y)
        {
            if (InBounds(x, y) == true && TileArray[x, y].OccupyingPlayer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Queries (read only)

        #region Updates

        public Validations.ValidationResultDto<string> PlaceActor(Player player, int x, int y)
        {
            if (InBounds(x, y) == false)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Position not on map"
                };
            }
            if (IsTileOccupied(x, y) == true)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Tile is already occupied"
                };
            }
            if (_actors.ContainsKey(player.PlayerId) == true)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Player is already placed on the map"
                };
            }

            TileArray[x, y].OccupyingPlayer = player;
            _actors.Add(player.PlayerId, (x, y));
            player.XCoordinate = x;
            player.YCoordinate = y;

            return new Validations.ValidationResultDto<string>
            {
                IsOK = true
            };
        }

        public Validations.ValidationResultDto<string> MoveActor(Player player, string movement)
        {
            int deltaX = 0;
            int deltaY = 0;

            movement = movement.ToLower();

            switch (movement)
            {
                case string upCheck when upCheck == Controls.ControlMapping.MovementUP:
                    deltaX = -1;
                    break;

                case string downCheck when downCheck == Controls.ControlMapping.MovementDOWN:
                    deltaX = 1;
                    break;

                case string leftCheck when leftCheck == Controls.ControlMapping.MovementLEFT:
                    deltaY = -1;
                    break;

                case string rightCheck when rightCheck == Controls.ControlMapping.MovementRIGHT:
                    deltaY = 1;
                    break;

                case string exitCheck when exitCheck == Controls.ControlMapping.ExitMenu:
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "exit"
                    };

                default:
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "Invalid movement command"
                    };
            }

            int newX = player.XCoordinate + deltaX;
            int newY = player.YCoordinate + deltaY;

            if (player.ChosenCharacter.CurrentMovementPoints <= 0 || player.ChosenCharacter.CurrentMovementPoints < TileArray[newX, newY].Terrain.MovementCost)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You don't have enough movement points"
                };
            }
            if (InBounds(newX, newY) != true)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You can't move anymore in that direction"
                };
            }
            if (TileArray[newX, newY].Terrain.IsWalkable == false)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You can't move there, the terrain is not walkable"
                };
            }
            if (IsTileOccupied(newX, newY) == true)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You can't move there, the tile is already occupied"
                };
            }

            TileArray[newX, newY].OccupyingPlayer = player;
            TileArray[player.XCoordinate, player.YCoordinate].OccupyingPlayer = null;
            player.XCoordinate = newX;
            player.YCoordinate = newY;
            player.ChosenCharacter.CurrentMovementPoints -= TileArray[newX, newY].Terrain.MovementCost;
            _actors[player.PlayerId] = (newX, newY);

            return new Validations.ValidationResultDto<string>
            {
                IsOK = true
            };
        }

        public void ModifyTileTerrain(int x, int y, Terrain terrain)
        {
            TileArray[x, y].Terrain = terrain;
        }

        public void createGrassTerrainMap()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    TileArray[row, col].Terrain = new GrassTerrain();
                }
            }
        }

        #endregion Updates
    }
}