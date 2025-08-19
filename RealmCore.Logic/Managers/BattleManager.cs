using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Managers
{
    public class BattleManager
    {
        public Player Player { get; set; }

        public BattleField BattleField { get; set; }

        public BattleManager(Player player, int height, int width)
        {
            Player = player;
            BattleField = new BattleField(player, height, width);
            InitializeTiles(BattleField);
        }

        public void InitializeTiles(BattleField battleField)
        {
            for (int row = 0; row < BattleField.Height; row++)
            {
                for (int col = 0; col < BattleField.Width; col++)
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
            for (int row = 0; row < BattleField.Height; row++)
            {
                for (int col = 0; col < BattleField.Width; col++)
                {
                    BattleField.TileArray[row, col].Terrain = new GrassTerrain();
                }
            }
        }

        public Validations.ValidationResultDto<string> PlayerMovement(string movement)
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

            int newX = Player.XCoordinate + deltaX;
            int newY = Player.YCoordinate + deltaY;

            if (Player.ChosenCharacter.CurrentMovementPoints <= 0)
            {
                return new Validations.ValidationResultDto<string>
                {
                    IsOK = false,
                    ErrorMessage = "You don't have enough movement points"
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
                    ErrorMessage = "You can't move there, the terrain is not walkable"
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

        //public void BattleMenu(string input)
        //{
        //    switch (input)
        //    {
        //        case "1" or "move":
        //            //PlayerMovement();
        //            ;
        //            case "2" or "attack":

        //            break;
        //        default:
        //    }
        //}

        //public Validations.ValidationResultDto<string> MovementMenu(string input)
        //{
        //}
    }
}