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
        private Guid PlayerGuid;
        private int PlayerDistance;

        public MoveState(Guid guid, int distance)
        {
            PlayerGuid = guid;
            PlayerDistance = distance;
        }

        public void TryState()
        {
            Console.WriteLine($"{PlayerGuid} at {PlayerDistance}");
        }

        public IDefaultState ChangeState()
        {
            return this;
        }
    }
}