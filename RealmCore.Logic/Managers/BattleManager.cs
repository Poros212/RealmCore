using RealmCore.Logic.AI;
using RealmCore.Logic.Battle;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.SnapShots;
using RealmCore.Logic.Tiles;

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
                if (actor.typeFlag == "player")
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

        public void TurnMovement(Player actor)
        {
            ActiveActor = actor;
            CTX.ActiveActorId = actor.ActorId;

            if (actor.TypeFlag == "player" && actor.IsAlive)
            {
                while (true)
                {
                    string? errorMessage = CTX.BattleField.MoveActor(ActiveActor, BattlefieldImplementation.TryMove(ActiveActor)).ErrorMessage;

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
            else if (actor.TypeFlag == "enemy" && actor.IsAlive)
            {
                List<Tile> tilesWalked = new List<Tile>();

                while (true)
                {
                    var ctxSnap = SnapshotFactoryBattle.CreateSnapshotBattleContext(CTX);
                    DefaultAi defaultAi = new DefaultAi(ctxSnap);
                    var action = defaultAi.TakeTurn();
                    if (ActiveActor.ChosenCharacter.CurrentMovementPoints > 0 && action.Value != "exit")
                    {
                        Tile tempTile = CTX.BattleField.TileArray[ActiveActor.XCoordinate, ActiveActor.YCoordinate];
                        tilesWalked.Add(tempTile);
                        CTX.BattleField.MoveActor(ActiveActor, action.Value);
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
            else
            {
                Console.WriteLine("error");
                Console.ReadKey();
            }
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
                            exitCheck = ActionMenu(actor);
                        }
                    }
                    else if (actor.TypeFlag == "enemy" && actor.IsAlive)
                    {
                        TurnMovement(actor);
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

        public bool ActionMenu(Player actor)
        {
            ActiveActor = actor;
            CTX.ActiveActorId = actor.ActorId;

            int choice = BattlefieldImplementation.DisplayBattleMenu();

            switch (choice)
            {
                case 1:
                    TurnMovement(actor);
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
    }
}