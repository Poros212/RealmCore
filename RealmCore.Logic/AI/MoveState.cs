using RealmCore.Logic.Battle;
using RealmCore.Logic.SnapShots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public class MoveState : IDefaultState
    {
        public void TryState()
        { }

        public IDefaultState ChangeState()
        { return this; }
    }
}