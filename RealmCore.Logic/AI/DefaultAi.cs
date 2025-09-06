using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public class DefaultAi
    {
        public SnapshotBattleContext CTX { get; }

        public DefaultAi(SnapshotBattleContext ctx)
        {
            CTX = ctx;
        }

        public ValidationResultDto<string> TakeTurn()
        {
            IdleState idleState = new IdleState(CTX);
            return idleState.TryState();
        }
    }
}