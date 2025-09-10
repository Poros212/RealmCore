using RealmCore.Logic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public enum StateEnum
    {
        IdelState = 0,
        MoveState = 1,
    }

    public interface IDefaultState
    {
        public DtoValidationResult<string> TryState();

        public DtoValidationResult<string> ChangeState(string value);
    }
}