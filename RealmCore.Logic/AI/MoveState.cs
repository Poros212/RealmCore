using RealmCore.Logic.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public class MoveState : IDefaultState
    {
        private BattleContext BattleContext { get; }

        public MoveState(BattleContext ctx)
        {
            BattleContext = ctx;
        }

        public void TryState(Enemy enemy)
        {
        }

        public IDefaultState ChangeState()
        {
            return this;
        }
    }
}