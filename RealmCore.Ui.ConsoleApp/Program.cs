using RealmCore.Logic;
using RealmCore.Logic.Characters;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using RealmCore.Logic.Validations;
using RealmCore.UI.ConsoleApp.Implementations;
using RealmCore.UI.ConsoleApp.Map;
using System.Runtime.InteropServices;

namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Console maximized to full window.");
            Console.ReadKey();

            Console.WriteLine("Hello, World!");

            IPlayerCreationUI playerCreationUI = new PlayerCreationUI();

            PlayerCreationManager playerCreationManager = new PlayerCreationManager(playerCreationUI);

            //Player playerCharacter = playerCreationManager.CreatePlayer();
            //Player player = playerCreationManager.CreatePlayer().Value;

            //Console.WriteLine($"Welcome {player.Name}, you have chosen the {player.ChosenCharacter.Name} class.");
            //Console.ReadKey();

            //Console.WriteLine("REALMCORE");
            //Console.WriteLine("New Game");
            //Console.WriteLine("Continue");

            Player player = new Player("Hero", new Apprentice());

            BattleManager battleManager = new BattleManager(player, 20, 10);

            BattlefieldUI battlefieldUi = new BattlefieldUI(battleManager);

            //battlefield.Tile[7, 7] = battlefield.ModifyTile(battlefield.Tile[7, 7], new GrassTile());

            //battlefield.Tile[5, 5].OccupyingPlayer = player;

            //battlefield.Tile[2, 2].OccupyingPlayer = player;
            //battlefield.Tile[5, 5].OccupyingPlayer = null;

            //battleManager.createGrassTerrainMap();

            battleManager.ModifyTileTerrain(4, 4, new WaterTerrain());
            battleManager.ModifyTileTerrain(3, 3, new WallTerrain());

            player.XCoordinate = 5;
            player.YCoordinate = 5;

            battleManager.BattleField.TileArray[player.XCoordinate, player.YCoordinate].OccupyingPlayer = player;

            //// battlefieldUi.DisplayMap();

            //battlefieldUi.UpdateMapMovement();

            //battlefield.Tile[5, 5].OccupyingPlayer.Name = "test2";

            //Console.WriteLine(player.Name);

            //BattlefieldUI test = Battlefield.;

            battlefieldUi.MovementMenu();

            //battlefieldUi.DisplayBattleFieldLegend();

            Console.ReadKey();
        }
    }
}