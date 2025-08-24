using RealmCore.Logic.Battle;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic.Managers
{
    public class BattleManager
    {
        public BattleContext CTX { get; set; }
        public IBattlefield? BattlefieldImplementation { get; set; }
        public List<Player> TurnOrder { get; set; } = new List<Player>();
        public Player ActiveActor { get; set; }

        public BattleManager(BattleContext ctx, IBattlefield? battlefieldUi)
        {
            CTX = ctx;
            BattlefieldImplementation = battlefieldUi;
        }

        public void StartBattle()
        {
            CreateTurnOrder();
        }

        public void CreateTurnOrder()
        {
            foreach (var player in CTX.Players)
            {
                TurnOrder.Add(player);
            }
            foreach (var enemy in CTX.Enemies)
            {
                TurnOrder.Add(enemy);
            }

            Random rng = new Random();

            TurnOrder = TurnOrder
                .OrderByDescending(actor => actor.ChosenCharacter.Speed)
                .ThenBy(_ => rng.Next())
                .ToList();
        }

        public void TestTurnOrderDisplay()
        {
            int x = 0;
            int y = 0;

            foreach (var actor in TurnOrder)
            {
                ActiveActor = actor;
                CTX.BattleField.PlaceActor(ActiveActor, x, y);
                x++;
                y++;
            }

            while (true)
            {
                var temp = CTX.BattleField.MoveActor(ActiveActor, BattlefieldImplementation.TryMove());

                if (temp.IsOK == false && temp.ErrorMessage != "exit")
                {
                    BattlefieldImplementation.ShowError(temp.ErrorMessage);
                }
                else if (temp.ErrorMessage == "exit")
                {
                    break;
                }
            }
        }
    }
}