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
            //Dictionary<Guid, int> actorsDistance = new Dictionary<Guid, int>();
            //Dictionary<Guid, int> actorsHealth = new Dictionary<Guid, int>();
            //SnapshotEnemy? activeEnemy = null;

            //foreach (var enemy in CTX.Enemies)
            //{
            //    if (enemy.ActorId == CTX.ActiveActorId)
            //    {
            //        activeEnemy = enemy;
            //    }
            //}

            //foreach (var actor in CTX.Players)
            //{
            //    if (actor.TypeFlag == "player" && actor.IsAlive)
            //    {
            //        int actorx = actor.XCoordinate;
            //        int actory = actor.YCoordinate;

            //        int distance = Math.Abs(activeEnemy.XCoordinate - actorx) + Math.Abs(activeEnemy.YCoordinate - actory);

            //        actorsDistance.Add(actor.ActorId, distance);
            //    }
            //}

            //Guid actorID = Guid.Empty;
            //int minDistance = int.MaxValue;

            //foreach (var actor in actorsDistance)
            //{
            //    if (actor.Value < minDistance)
            //    {
            //        minDistance = actor.Value;
            //        actorID = actor.Key;
            //    }
            //}

            //return new MoveState(actorID, minDistance);
        }
    }
}