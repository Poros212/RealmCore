using RealmCore.Logic.SnapShots;
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

        public IDefaultState TakeTurn()
        {
            int moveReward = 0;
            int attackReward = 0;
            Dictionary<Guid, int> actorsDistance = new Dictionary<Guid, int>();
            Dictionary<Guid, int> actorsHealth = new Dictionary<Guid, int>();

            foreach (var actor in CTX.Players)
            {
                if (actor.TypeFlag == "player")
                {
                }
            }
            IDefaultState test = new MoveState();
            return test;
        }
    }
}