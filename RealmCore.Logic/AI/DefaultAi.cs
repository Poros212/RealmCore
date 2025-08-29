using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.AI
{
    public class DefaultAi
    {
        public BattleSnapshot BattleSnapshot { get; }

        public DefaultAi(BattleSnapshot battleSnapshot)
        {
            BattleSnapshot = battleSnapshot;
        }
    }
}