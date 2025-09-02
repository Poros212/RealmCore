using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic;
using RealmCore.Logic.Maps;

namespace RealmCore.Logic.Battle
{
    public sealed class BattleContext
    {
        public List<Player> Players { get; set; }
        public List<Enemy> Enemies { get; set; }
        public BattleField BattleField { get; set; }
        public int Turn { get; set; } = 1;
        public Guid? ActiveActorId { get; set; } = null;

        public BattleContext(List<Player> players, List<Enemy> enemies, BattleField field)
        {
            Players = players;
            Enemies = enemies;
            BattleField = field;
        }
    }
}