using RealmCore.Logic;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Maps;
using RealmCore.UI.ConsoleApp.Implementations;
using RealmCore.UI.ConsoleApp.Map;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Characters;
using RealmCore.Logic.Tiles.Terrains;
using RealmCore.Logic.Validations;

namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //IPlayerCreationUI playerCreationUI = new PlayerCreationConsoleUI();

            //PlayerCreationManager playerCreationManager = new PlayerCreationManager(playerCreationUI);

            //Player playerCharacter = playerCreationManager.CreatePlayer();

            //Console.WriteLine($"Welcome {playerCharacter.Name}, you have chosen the {playerCharacter.ChosenCharacter.Name} class.");

            //Console.WriteLine("REALMCORE");
            //Console.WriteLine("New Game");
            //Console.WriteLine("Continue");

            Player player = new Player("Hero", new Apprentice());

            BattleManager battleManager = new BattleManager(player);

            BattlefieldUI battlefieldUi = new BattlefieldUI(battleManager);

            //battlefield.Tile[7, 7] = battlefield.ModifyTile(battlefield.Tile[7, 7], new GrassTile());

            //battlefield.Tile[5, 5].OccupyingPlayer = player;

            //battlefield.Tile[2, 2].OccupyingPlayer = player;
            //battlefield.Tile[5, 5].OccupyingPlayer = null;

            battleManager.createGrassTerrainMap();

            battleManager.ModifyTileTerrain(4, 4, new Terrain());

            player.XCoordinate = 5;
            player.YCoordinate = 5;

            battleManager.BattleField.TileArray[player.XCoordinate, player.YCoordinate].OccupyingPlayer = player;

            // battlefieldUi.DisplayMap();

            while (true)
            {
                battlefieldUi.DisplayMap();
                Console.Write("move: ");
                string tmp = Console.ReadLine();
                ValidationResultDto<string> movementResult = battleManager.PlayerMovement(tmp);
                if (movementResult.IsOK == false)
                {
                    UiFormat.DisplayError(movementResult.ErrorMessage);
                    continue;
                }

                //UiFormat.UiPressAnyKey();
            }

            //battlefield.Tile[5, 5].OccupyingPlayer.Name = "test2";

            //Console.WriteLine(player.Name);

            //BattlefieldUI test = Battlefield.;

            Console.ReadKey();
        }
    }
}