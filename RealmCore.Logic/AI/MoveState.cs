using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Validations;
using Spectre.Console;

namespace RealmCore.Logic.AI
{
    public class MoveState : IDefaultState
    {
        public SnapshotBattleContext CTX { get; }

        public MoveState(SnapshotBattleContext ctx)
        {
            CTX = ctx;
        }

        public DtoValidationResult<string> TryState()
        {
            return TryMoveTwoardsActor(FindNearestPlayer());
        }

        public DtoValidationResult<string> ChangeState(string value)
        {
            switch (value)
            {
                case "idle":
                    return new IdleState(CTX).TryState();

                default:
                    return new DtoValidationResult<string>
                    {
                        IsOK = false,
                        ErrorMessage = "Invalid state change"
                    };
            }
        }

        public bool SurroundingsCheck(int x, int y, SnapshotBattleContext ctx)
        {
            if (x >= 0 && x < ctx.Battlefield.Width && y >= 0 && y < ctx.Battlefield.Height)
            {
                if (CTX.Battlefield.TileArray[x, y].Terrain.IsWalkable)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public bool ActorAdjacentCheck(Dto_Int_Int_Generic<SnapshotEnemy> dto)
        {
            if (
                    (dto.ValueX - dto.GenericObject.XCoordinate == 0 && dto.ValueY - dto.GenericObject.YCoordinate == 1)
                    ||
                    (dto.ValueX - dto.GenericObject.XCoordinate == 0 && dto.ValueY - dto.GenericObject.YCoordinate == -1)
                    ||
                    (dto.ValueY - dto.GenericObject.YCoordinate == 0 && dto.ValueX - dto.GenericObject.XCoordinate == 1)
                    ||
                    (dto.ValueY - dto.GenericObject.YCoordinate == 0 && dto.ValueX - dto.GenericObject.XCoordinate == -1)
                )
            { return true; }
            else { return false; }
        }

        public Dto_Int_Int_Generic<SnapshotEnemy> FindNearestPlayer()
        {
            int moveRange = CTX.Enemies
                .Where(a => a.ActorId == CTX.ActiveActorId)
                .Select((b => b.ChosenCharacter.CurrentMovementPoints))
                .FirstOrDefault();

            int actorX = 0;
            int actorY = 0;

            Dictionary<Guid, int> actorsDistance = new Dictionary<Guid, int>();
            Dictionary<Guid, int> actorsHealth = new Dictionary<Guid, int>();
            SnapshotEnemy? activeEnemy = null;

            foreach (var enemy in CTX.Enemies)
            {
                if (enemy.ActorId == CTX.ActiveActorId)
                {
                    activeEnemy = enemy;
                }
            }

            foreach (var actor in CTX.Players)
            {
                if (actor.TypeFlag == "player" && actor.IsAlive)
                {
                    actorX = actor.XCoordinate;
                    actorY = actor.YCoordinate;

                    int distance = Math.Abs(activeEnemy.XCoordinate - actorX) + Math.Abs(activeEnemy.YCoordinate - actorY);

                    actorsDistance.Add(actor.ActorId, distance);
                }
            }

            Guid actorID = Guid.Empty;
            int minDistance = int.MaxValue;

            foreach (var actor in actorsDistance)
            {
                if (actor.Value < minDistance)
                {
                    minDistance = actor.Value;
                    actorID = actor.Key;
                    actorX = CTX.Players.Where(a => a.ActorId == actorID).Select(b => b.XCoordinate).FirstOrDefault();
                    actorY = CTX.Players.Where(a => a.ActorId == actorID).Select(b => b.YCoordinate).FirstOrDefault();
                }
            }

            return new Dto_Int_Int_Generic<SnapshotEnemy>
            {
                IsOK = true,
                ValueX = actorX,
                ValueY = actorY,
                GenericObject = activeEnemy
            };
        }

        //public DtoValidationResult<string> TryMoveTowardsPlayer(Dto_Int_Int_Generic<SnapshotEnemy> dto)
        //{
        //    if (!ActorAdjacentCheck(dto))
        //    {
        //        // use random to decide direction to move so its not always the same
        //        // if y or x is 0 and the inverse is blocked wont navigate around

        //        if (dto.ValueX - dto.GenericObject.XCoordinate > 0)
        //        {
        //            bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate + 1, dto.GenericObject.YCoordinate);

        //            if (freeSpace)
        //            {
        //                return new DtoValidationResult<string>()
        //                {
        //                    IsOK = true,
        //                    Value = Controls.ControlMapping.MovementDOWN
        //                };
        //            }
        //        }
        //        if (dto.ValueX - dto.GenericObject.XCoordinate < 0)
        //        {
        //            bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate - 1, dto.GenericObject.YCoordinate);

        //            if (freeSpace)
        //            {
        //                return new DtoValidationResult<string>()
        //                {
        //                    IsOK = true,
        //                    Value = Controls.ControlMapping.MovementUP
        //                };
        //            }
        //        }
        //        if (dto.ValueY - dto.GenericObject.YCoordinate > 0)
        //        {
        //            bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate + 1);
        //            if (freeSpace)
        //            {
        //                return new DtoValidationResult<string>()
        //                {
        //                    IsOK = true,
        //                    Value = Controls.ControlMapping.MovementRIGHT
        //                };
        //            }
        //        }
        //        if (dto.ValueY - dto.GenericObject.YCoordinate < 0)
        //        {
        //            bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate - 1);
        //            if (freeSpace)
        //            {
        //                return new DtoValidationResult<string>()
        //                {
        //                    IsOK = true,
        //                    Value = Controls.ControlMapping.MovementLEFT
        //                };
        //            }
        //        }
        //    }
        //    return new DtoValidationResult<string>()
        //    {
        //        IsOK = false,
        //        ErrorMessage = "No available spaces to move"
        //    };
        //}

        public DtoValidationResult<string> TryMoveTwoardsActor(Dto_Int_Int_Generic<SnapshotEnemy> dto)
        {
            List<string> movmentOptions = new List<string>();

            if (!ActorAdjacentCheck(dto))
            {
                if (dto.ValueX - dto.GenericObject.XCoordinate > 0)
                {
                    bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate + 1, dto.GenericObject.YCoordinate, CTX);

                    if (freeSpace)
                    {
                        movmentOptions.Add(Controls.ControlMapping.MovementDOWN);
                    }
                }
                if (dto.ValueX - dto.GenericObject.XCoordinate < 0)
                {
                    bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate - 1, dto.GenericObject.YCoordinate, CTX);

                    if (freeSpace)
                    {
                        movmentOptions.Add(Controls.ControlMapping.MovementUP);
                    }
                }
                if (dto.ValueY - dto.GenericObject.YCoordinate > 0)
                {
                    bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate + 1, CTX);
                    if (freeSpace)
                    {
                        movmentOptions.Add(Controls.ControlMapping.MovementRIGHT);
                    }
                }
                if (dto.ValueY - dto.GenericObject.YCoordinate < 0)
                {
                    bool freeSpace = SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate - 1, CTX);
                    if (freeSpace)
                    {
                        movmentOptions.Add(Controls.ControlMapping.MovementLEFT);
                    }
                }
            }
            else
            {
                return new DtoValidationResult<string>()
                {
                    IsOK = true,
                    Value = "exit"
                };
            }
            if (movmentOptions.Count == 0)
            {
                if (SurroundingsCheck(dto.GenericObject.XCoordinate + 1, dto.GenericObject.YCoordinate, CTX))
                {
                    movmentOptions.Add(Controls.ControlMapping.MovementDOWN);
                }
                if (SurroundingsCheck(dto.GenericObject.XCoordinate - 1, dto.GenericObject.YCoordinate, CTX))
                {
                    movmentOptions.Add(Controls.ControlMapping.MovementUP);
                }
                if (SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate + 1, CTX))
                {
                    movmentOptions.Add(Controls.ControlMapping.MovementRIGHT);
                }
                if (SurroundingsCheck(dto.GenericObject.XCoordinate, dto.GenericObject.YCoordinate - 1, CTX))
                {
                    movmentOptions.Add(Controls.ControlMapping.MovementLEFT);
                }
            }
            // if still no options available exit turn
            if (movmentOptions.Count == 0)
            {
                return new DtoValidationResult<string>()
                {
                    IsOK = true,
                    Value = "exit"
                };
            }

            int randomIndex = new Random().Next(movmentOptions.Count);

            return new DtoValidationResult<string>()
            {
                IsOK = true,
                Value = movmentOptions[randomIndex]
            };
        }
    }
}