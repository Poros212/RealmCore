using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Interfaces
{
    public interface IBattlefield
    {
        int DisplayBattleMenu();

        string TryMove(Player player);

        void ShowError(string message);
    }
}