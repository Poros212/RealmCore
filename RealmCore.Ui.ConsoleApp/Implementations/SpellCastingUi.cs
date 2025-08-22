using RealmCore.Logic.Interfaces;
using RealmCore.UI.ConsoleApp.Map;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.UI.ConsoleApp.Implementations
{
    public class SpellCastingUi : ISpellCast
    {
        private BattlefieldUI BattlefieldUI { get; set; }

        public SpellCastingUi(BattlefieldUI battlefieldUI)
        {
            BattlefieldUI = battlefieldUI;
        }

        public void DisplaySpellTravel(int x, int y)
        {
            BattlefieldUI.DisplayMapWithSpell("**", x, y);
            //Thread.Sleep(200);
            Task.Delay(1000).Wait(); // Use Task.Delay for asynchronous delay
            AnsiConsole.Clear();
        }
    }
}