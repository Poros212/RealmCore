using RealmCore.Logic.AI;
using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Interfaces;

namespace RealmCore.Logic.Battle
{
    public class BattleOptions
    {
        public BattleContext CTX { get; set; }
        public IBattlefield? BattlefieldImplementation { get; set; }

        public BattleOptions(BattleContext ctx, IBattlefield battlefield)
        {
            CTX = ctx;
            BattlefieldImplementation = battlefield;
        }

        public bool ActionMenu(Player actor)
        {
            //SetActiveActor(actor);

            int choice = BattlefieldImplementation.DisplayBattleMenu();

            switch (choice)
            {
                case 1:
                    PlayerTurnMovement(actor);
                    return true;

                case 2:
                    //battlemenu
                    return true;

                case 3:
                    return false;

                default:
                    return false;
            }
        }

        public void EnemyActions(Player actor)
        {
            EnemyTurnMovement(actor);
        }

        //public void SetActiveActor(Player actor)
        //{
        //    ActiveActor = actor;
        //    CTX.ActiveActorId = actor.ActorId;
        //}

        public DefaultAi InitiateEnemyAi()
        {
            var ctxSnap = SnapshotFactoryBattle.CreateSnapshotBattleContext(CTX);
            return new DefaultAi(ctxSnap);
        }

        public void PlayerTurnMovement(Player actor)
        {
            //SetActiveActor(actor);

            while (true)
            {
                string? errorMessage = CTX.BattleField.MoveActor(actor, BattlefieldImplementation.TryMove(actor)).ErrorMessage;

                if (errorMessage != null && errorMessage != "exit")
                {
                    BattlefieldImplementation.ShowError(errorMessage);
                }
                else if (errorMessage == "exit")
                {
                    break;
                }
            }
        }

        public void EnemyTurnMovement(Player actor)
        {
            List<Tile> tilesWalked = new List<Tile>();

            while (true)
            {
                //SetActiveActor(actor);

                DtoValidationResult<string> action = InitiateEnemyAi().TakeTurn();

                if (actor.ChosenCharacter.CurrentMovementPoints > 0 && action.Value != "exit")
                {
                    Tile tempTile = CTX.BattleField.TileArray[actor.XCoordinate, actor.YCoordinate];
                    tilesWalked.Add(tempTile);
                    CTX.BattleField.MoveActor(actor, action.Value);
                    CTX.BattleField.TileArray[tempTile.XAxis, tempTile.YAxis].Terrain.IsWalkable = false;
                }
                else
                {
                    foreach (var tile in tilesWalked)
                    {
                        CTX.BattleField.TileArray[tile.XAxis, tile.YAxis].Terrain.IsWalkable = true;
                    }
                    break;
                }
            }
        }
    }
}