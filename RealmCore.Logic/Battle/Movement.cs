//using RealmCore.Logic.Maps;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RealmCore.Logic.Battle
//{
//    public static class Movement
//    {
//        public Validations.ValidationResultDto<string> TryMove(BattleContext ctx, Player player, string movement)
//        {
//            int deltaX = 0;
//            int deltaY = 0;

//            movement = movement.ToLower();

//            switch (movement)
//            {
//                case string upCheck when upCheck == Controls.ControlMapping.MovementUP:
//                    deltaX = -1;
//                    break;

//                case string downCheck when downCheck == Controls.ControlMapping.MovementDOWN:
//                    deltaX = 1;
//                    break;

//                case string leftCheck when leftCheck == Controls.ControlMapping.MovementLEFT:
//                    deltaY = -1;
//                    break;

//                case string rightCheck when rightCheck == Controls.ControlMapping.MovementRIGHT:
//                    deltaY = 1;
//                    break;

//                case string exitCheck when exitCheck == Controls.ControlMapping.ExitMenu:
//                    return new Validations.ValidationResultDto<string>
//                    {
//                        IsOK = false,
//                        ErrorMessage = "exit"
//                    };

//                default:
//                    return new Validations.ValidationResultDto<string>
//                    {
//                        IsOK = false,
//                        ErrorMessage = "Invalid movement command"
//                    };
//            }

//            int newX = player.XCoordinate + deltaX;
//            int newY = player.YCoordinate + deltaY;

//            if (player.ChosenCharacter.CurrentMovementPoints <= 0 || player.ChosenCharacter.CurrentMovementPoints < ctx.BattleField.TileArray[newX, newY].Terrain.MovementCost)
//            {
//                return new Validations.ValidationResultDto<string>
//                {
//                    IsOK = false,
//                    ErrorMessage = "You don't have enough movement points"
//                };
//            }
//            if (ctx.BattleField.InBounds(newX, newY) != true)
//            {
//                return new Validations.ValidationResultDto<string>
//                {
//                    IsOK = false,
//                    ErrorMessage = "You can't move anymore in that direction"
//                };
//            }
//            if (ctx.BattleField.TileArray[newX, newY].Terrain.IsWalkable == false)
//            {
//                return new Validations.ValidationResultDto<string>
//                {
//                    IsOK = false,
//                    ErrorMessage = "You can't move there, the terrain is not walkable"
//                };
//            }
//            if (ctx.BattleField.IsTileOccupied(newX, newY) == true)
//            {
//                return new Validations.ValidationResultDto<string>
//                {
//                    IsOK = false,
//                    ErrorMessage = "You can't move there, the tile is already occupied"
//                };
//            }

//            return new Validations.ValidationResultDto<string>
//            {
//                IsOK = true,
//            };
//        }
//    }
//}