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

        public Validations.ValidationResultDto<string> PlayerMovement(string movement)
        {
            int deltaX = 0;
            int deltaY = 0;

            switch (movement)
            {
                case "up" or "8":
                    deltaX = -1;
                    break;

                case "down" or "2":
                    deltaX = 1;
                    break;

                case "left" or "4":
                    deltaY = -1;
                    break;

                case "right" or "6":
                    deltaY = 1;
                    break;

                default:
                    return new Validations.ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "Invalid movement command. Use 'up', 'down', 'left', or 'right'."
                    };
            }

            int newX = Player.XCoordinate + deltaX;
            int newY = Player.YCoordinate + deltaY;

            if (Player.ChosenCharacter.CurrentMovementPoints <= 0)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You don't have enough movement points."
                };
            }

            if (newX < 0 || newX > BattleField.Height || newY < 0 || newY > BattleField.Width)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You can't move anymore in that direction"
                };
            }

            if (!BattleField.TileArray[newX, newY].Terrain.IsWalkable)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You can't move there, the terrain is not walkable."
                };
            }

            BattleField.TileArray[newX, newY].OccupyingPlayer = Player;
            BattleField.TileArray[Player.XCoordinate, Player.YCoordinate].OccupyingPlayer = null;
            Player.XCoordinate = newX;
            Player.YCoordinate = newY;
            Player.ChosenCharacter.CurrentMovementPoints -= BattleField.TileArray[newX, newY].Terrain.MovementCost;

            return new Validations.ValidationResultDto<string>
            {
                IsOK = true
            };
        }
    }
}