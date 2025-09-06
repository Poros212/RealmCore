using RealmCore.Logic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public interface IDefaultState
    {
        public ValidationResultDto<string> TryState();

        public ValidationResultDto<string> ChangeState(string value);
    }
}