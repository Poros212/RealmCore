using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Validations;

namespace RealmCore.Logic.AI
{
    public class IdleState : IDefaultState
    {
        public SnapshotBattleContext CTX { get; }

        public IdleState(SnapshotBattleContext ctx)
        {
            CTX = ctx;
        }

        public ValidationResultDto<string> TryState()
        {
            var activeActor = CTX.Enemies.FirstOrDefault(e => e.ActorId == CTX.ActiveActorId);

            if (activeActor.ChosenCharacter.CurrentMovementPoints > 0)
            {
                return new MoveState(CTX).TryState();
            }
            else
            {
                return new ValidationResultDto<string>
                {
                    IsOK = true,
                    ErrorMessage = "No movement points",
                    Value = "exit"
                };
            }
        }

        public ValidationResultDto<string> ChangeState(string value)
        {
            switch (value)
            {
                case "move":
                    return new MoveState(CTX).TryState();

                default:
                    return new ValidationResultDto<string>
                    {
                        IsOK = false,
                        ErrorMessage = "Invalid state change"
                    };
            }
        }
    }
}