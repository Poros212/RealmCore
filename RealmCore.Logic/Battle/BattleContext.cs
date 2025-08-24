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
        public List<Player> Players { get; }
        public List<Enemy> Enemies { get; }
        public BattleField BattleField { get; }
        public int Turn { get; set; } = 1;
        public Guid? ActivePlayerId { get; set; } = null;

        public BattleContext(IEnumerable<Player> players, IEnumerable<Enemy> enemies, BattleField battleField)
        {
            Players = players.ToList();
            Enemies = enemies.ToList();
            BattleField = battleField;
        }
    }
}