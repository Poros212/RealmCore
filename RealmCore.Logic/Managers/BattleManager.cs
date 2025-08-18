using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Managers
{
    public class BattleManager
    {
        public Player Player { get; set; }

        public BattleField BattleField { get; set; }

        public BattleManager(Player player)
        {
            Player = player;
            BattleField = new BattleField(player);
            InitializeTiles(BattleField);
        }

        public void InitializeTiles(BattleField battleField)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    battleField.TileArray[row, col] = new Tile(row, col);
                }
            }
        }

        public void ModifyTileTerrain(int x, int y, Terrain terrain)
        {
            BattleField.TileArray[x, y].Terrain = terrain;
        }

        public void createGrassTerrainMap()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    BattleField.TileArray[row, col].Terrain = new GrassTerrain();
                }
            }
        }

        #region Movement

        public Validations.ValidationResultDto<string> PlayerMovement(string playerMovement)
        {
            if (playerMovement == "up" || playerMovement == "8")
            {
                int tmpX = Player.XCoordinate;
                int tmpY = Player.YCoordinate;

                try
                {
                    int testX = Player.XCoordinate - 1;
                    int testY = Player.YCoordinate;
                    BattleField.TileArray[testX, testY].OccupyingPlayer = Player;
                }
                catch (Exception)
                {
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "You can't move further up!"
                    };
                }

                Player.XCoordinate--;
                BattleField.TileArray[tmpX, tmpY].OccupyingPlayer = null;
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = true
                };
            }
            else if (playerMovement == "down" || playerMovement == "2")
            {
                int tmpX = Player.XCoordinate;
                int tmpY = Player.YCoordinate;

                try
                {
                    int testX = Player.XCoordinate + 1;
                    int testY = Player.YCoordinate;
                    BattleField.TileArray[testX, testY].OccupyingPlayer = Player;
                }
                catch (Exception)
                {
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "You can't move further down!"
                    };
                }

                Player.XCoordinate++;
                BattleField.TileArray[tmpX, tmpY].OccupyingPlayer = null;
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = true
                };
            }
            else if (playerMovement == "left" || playerMovement == "4")
            {
                int tmpX = Player.XCoordinate;
                int tmpY = Player.YCoordinate;

                try
                {
                    int testX = Player.XCoordinate;
                    int testY = Player.YCoordinate - 1;
                    BattleField.TileArray[testX, testY].OccupyingPlayer = Player;
                }
                catch (Exception)
                {
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "You can't move further left!"
                    };
                }

                Player.YCoordinate--;
                BattleField.TileArray[tmpX, tmpY].OccupyingPlayer = null;
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = true
                };
            }
            else if (playerMovement == "right" || playerMovement == "6")
            {
                int tmpX = Player.XCoordinate;
                int tmpY = Player.YCoordinate;

                try
                {
                    int testX = Player.XCoordinate;
                    int testY = Player.YCoordinate + 1;
                    BattleField.TileArray[testX, testY].OccupyingPlayer = Player;
                }
                catch (Exception)
                {
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "You can't move further right!"
                    };
                }

                Player.YCoordinate++;
                BattleField.TileArray[tmpX, tmpY].OccupyingPlayer = null;
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = true
                };
            }
            else
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "Invalid movement command. Use 'up', 'down', 'left', or 'right'."
                };
            }

            #endregion Movement
        }
    }
}