using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public interface IDefaultState
    {
        public void TryState();

        public IDefaultState ChangeState();
    }
}