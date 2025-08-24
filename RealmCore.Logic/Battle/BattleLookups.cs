using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Battle
{
    public static class BattleLookups
    {
        public static Player? GetPlayerById(BattleContext ctx, Guid playerId)
        {
            foreach (var player in ctx.Players)
            {
                if (player.PlayerId == playerId)
                {
                    return player;
                }
            }
            return null;
        }
    }
}