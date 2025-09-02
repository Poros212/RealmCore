using RealmCore.Logic.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotBattleContext
    {
        public IReadOnlyList<SnapshotPlayer> Players { get; }
        public IReadOnlyList<SnapshotEnemy> Enemies { get; }
        public SnapshotBattlefield Battlefield { get; }
        public int Turn { get; }
        public Guid? ActiveActorId { get; }

        public SnapshotBattleContext(
            IReadOnlyList<SnapshotPlayer> players,
            IReadOnlyList<SnapshotEnemy> enemies,
            SnapshotBattlefield battlefield,
            int turn,
            Guid? activePlayerId)
        {
            Players = players;
            Enemies = enemies;
            Battlefield = battlefield;
            Turn = turn;
            ActiveActorId = activePlayerId;
        }
    }
}