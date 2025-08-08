using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;

namespace RealmCore.Logic.Interfaces
{
    public interface IPlayerCreationUI
    {
        string EnterName();
        string ChooseCharacter();
    }
}
