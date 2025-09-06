using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Validations;

namespace RealmCore.Logic.AI
{
    public class MoveState : IDefaultState
    {
        public SnapshotBattleContext CTX { get; }

        public MoveState(SnapshotBattleContext ctx)
        {
            CTX = ctx;
        }

        public ValidationResultDto<string> TryState()
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

            if (
                !(actorX - activeEnemy.XCoordinate == 0 && actorY - activeEnemy.XCoordinate == 1)
                ||
                !(actorX - activeEnemy.XCoordinate == 0 && actorY - activeEnemy.XCoordinate == -1)
                ||
                !(actorY - activeEnemy.YCoordinate == 0 && actorX - activeEnemy.XCoordinate == 1)
                ||
                !(actorY - activeEnemy.YCoordinate == 0 && actorX - activeEnemy.XCoordinate == -1)
                )
            {
                // use random to decide direction to move so its not always the same

                if (actorX - activeEnemy.XCoordinate > 0)
                {
                    //move right
                    return new ValidationResultDto<string>()
                    {
                        IsOK = true,
                        Value = Controls.ControlMapping.MovementDOWN
                    };
                }
                if (actorX - activeEnemy.XCoordinate < 0)
                {
                    //move left
                    return new ValidationResultDto<string>()
                    {
                        IsOK = true,
                        Value = Controls.ControlMapping.MovementUP
                    };
                }
                if (actorY - activeEnemy.XCoordinate > 0)
                {
                    //move down
                    return new ValidationResultDto<string>()
                    {
                        IsOK = true,
                        Value = Controls.ControlMapping.MovementRIGHT
                    };
                }
                if (actorY - activeEnemy.XCoordinate < 0)
                {
                    //move up
                    return new ValidationResultDto<string>()
                    {
                        IsOK = true,
                        Value = Controls.ControlMapping.MovementLEFT
                    };
                }
            }

            return new ValidationResultDto<string>()
            {
                IsOK = false,
                ErrorMessage = "No movement needed"
            };
        }

        public ValidationResultDto<string> ChangeState(string value)
        {
            return new ValidationResultDto<string>
            {
                IsOK = false,
                ErrorMessage = "attack feature not available"
            };
        }
    }
}