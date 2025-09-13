using RealmCore.Logic.AI;
using RealmCore.Logic.Battle;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Validations;

namespace RealmCore.Logic.Managers
{
    public class BattleManager
    {
        public BattleContext CTX { get; set; }
        public IBattlefield? BattlefieldImplementation { get; set; }
        public List<Player> TurnOrder { get; set; } = new List<Player>();
        public Player ActiveActor { get; set; }
        public BattleOptions BattleOptions { get; set; }

        public BattleManager(BattleContext ctx, IBattlefield? battlefieldUi)
        {
            CTX = ctx;
            BattlefieldImplementation = battlefieldUi;
            //BattleOptions = new BattleOptions(CTX, BattlefieldImplementation);
        }

        public void StartBattle()
        {
            CreateTurnOrder();
            PlaceActorsOnField();
            BattleFlow();
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
        }

        public void PlaceActorsOnField()
        {
            foreach (var actor in TurnOrder)
            {
                if (actor.TypeFlag == "player")
                {
                    int y = 7;
                    CTX.BattleField.PlaceActor(actor, (CTX.BattleField.Height - 1), y);
                    y++;
                }
                else
                {
                    int y = 7;
                    CTX.BattleField.PlaceActor(actor, 0, y);
                    y++;
                }
            }
        }

        //public void TurnMovement(Player actor, DtoValidationResult<string>? action)
        //{
        //    ActiveActor = actor;
        //    CTX.ActiveActorId = actor.ActorId;
        //    SetActiveActor(actor);
        //    if (actor.TypeFlag == "player" && actor.IsAlive)
        //    {
        //        while (true)
        //        {
        //            string? errorMessage = CTX.BattleField.MoveActor(ActiveActor, BattlefieldImplementation.TryMove(ActiveActor)).ErrorMessage;

        //            if (errorMessage != null && errorMessage != "exit")
        //            {
        //                BattlefieldImplementation.ShowError(errorMessage);
        //            }
        //            else if (errorMessage == "exit")
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    else if (actor.TypeFlag == "enemy" && actor.IsAlive)
        //    {
        //        List<Tile> tilesWalked = new List<Tile>();

        //        while (true)
        //        {
        //            //var ctxSnap = SnapshotFactoryBattle.CreateSnapshotBattleContext(CTX);
        //            //DefaultAi defaultAi = new DefaultAi(ctxSnap);
        //            //var action = defaultAi.TakeTurn();
        //            SetActiveActor(actor);
        //            InitiateEnemyAi();
        //            if (ActiveActor.ChosenCharacter.CurrentMovementPoints > 0 && action.Value != "exit")
        //            {
        //                Tile tempTile = CTX.BattleField.TileArray[ActiveActor.XCoordinate, ActiveActor.YCoordinate];
        //                tilesWalked.Add(tempTile);
        //                CTX.BattleField.MoveActor(ActiveActor, action.Value);
        //                CTX.BattleField.TileArray[tempTile.XAxis, tempTile.YAxis].Terrain.IsWalkable = false;
        //            }
        //            else
        //            {
        //                foreach (var tile in tilesWalked)
        //                {
        //                    CTX.BattleField.TileArray[tile.XAxis, tile.YAxis].Terrain.IsWalkable = true;
        //                }
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("error");
        //        Console.ReadKey();
        //    }
        //}

        public void SetActiveActor(Player actor)
        {
            ActiveActor = actor;
            CTX.ActiveActorId = actor.ActorId;
        }

        public void BattleFlow()
        {
            while (true)
            {
                foreach (var actor in TurnOrder)
                {
                    if (actor.TypeFlag == "player")
                    {
                        bool exitCheck = true;

                        while (exitCheck)
                        {
                            SetActiveActor(actor);
                            BattleOptions = new BattleOptions(CTX, BattlefieldImplementation);
                            exitCheck = BattleOptions.ActionMenu(actor);
                        }
                    }
                    else if (actor.TypeFlag == "enemy" && actor.IsAlive)
                    {
                        SetActiveActor(actor);
                        BattleOptions = new BattleOptions(CTX, BattlefieldImplementation);
                        BattleOptions.EnemyActions(actor);
                    }
                    else
                    {
                        continue;
                    }
                }
                foreach (var actor in TurnOrder)
                {
                    actor.ChosenCharacter.CurrentMovementPoints = actor.ChosenCharacter.MaxMovementPoints;
                }
                CTX.Turn++;
            }
        }

        //public bool ActionMenu(Player actor)
        //{
        //    SetActiveActor(actor);

        //    int choice = BattlefieldImplementation.DisplayBattleMenu();

        //    switch (choice)
        //    {
        //        case 1:
        //            PlayerTurnMovement(actor);
        //            return true;

        //        case 2:
        //            //battlemenu
        //            return true;

        //        case 3:
        //            return false;

        //        default:
        //            return false;
        //    }
        //}

        //public void EnemyActions(Player actor)
        //{
        //    EnemyTurnMovement(actor);
        //}

        //public void SetActiveActor(Player actor)
        //{
        //    ActiveActor = actor;
        //    CTX.ActiveActorId = actor.ActorId;
        //}

        //public DefaultAi InitiateEnemyAi()
        //{
        //    var ctxSnap = SnapshotFactoryBattle.CreateSnapshotBattleContext(CTX);
        //    return new DefaultAi(ctxSnap);
        //}

        //public void PlayerTurnMovement(Player actor)
        //{
        //    SetActiveActor(actor);

        //    while (true)
        //    {
        //        string? errorMessage = CTX.BattleField.MoveActor(ActiveActor, BattlefieldImplementation.TryMove(ActiveActor)).ErrorMessage;

        //        if (errorMessage != null && errorMessage != "exit")
        //        {
        //            BattlefieldImplementation.ShowError(errorMessage);
        //        }
        //        else if (errorMessage == "exit")
        //        {
        //            break;
        //        }
        //    }
        //}

        //public void EnemyTurnMovement(Player actor)
        //{
        //    List<Tile> tilesWalked = new List<Tile>();

        //    while (true)
        //    {
        //        SetActiveActor(actor);

        //        DtoValidationResult<string> action = InitiateEnemyAi().TakeTurn();

        //        if (ActiveActor.ChosenCharacter.CurrentMovementPoints > 0 && action.Value != "exit")
        //        {
        //            Tile tempTile = CTX.BattleField.TileArray[ActiveActor.XCoordinate, ActiveActor.YCoordinate];
        //            tilesWalked.Add(tempTile);
        //            CTX.BattleField.MoveActor(ActiveActor, action.Value);
        //            CTX.BattleField.TileArray[tempTile.XAxis, tempTile.YAxis].Terrain.IsWalkable = false;
        //        }
        //        else
        //        {
        //            foreach (var tile in tilesWalked)
        //            {
        //                CTX.BattleField.TileArray[tile.XAxis, tile.YAxis].Terrain.IsWalkable = true;
        //            }
        //            break;
        //        }
        //    }
        //}
    }
}