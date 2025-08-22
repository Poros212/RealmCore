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
using Spectre.Console;
using System.Runtime.InteropServices;
using RealmCore.Logic.Controls;
using RealmCore.Logic.Spells;

namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //ConsoleWindow.EnsureMaximizedOnce();
            Console.ReadKey();

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
            Player enemy = new Player("Enemy", new Apprentice());

            BattleManager battleManager = new BattleManager(player, enemy, 20, 10);

            BattlefieldUI battlefieldUi = new BattlefieldUI(battleManager);

            //battlefield.Tile[7, 7] = battlefield.ModifyTile(battlefield.Tile[7, 7], new GrassTile());

            //battlefield.Tile[5, 5].OccupyingPlayer = player;

            //battlefield.Tile[2, 2].OccupyingPlayer = player;
            //battlefield.Tile[5, 5].OccupyingPlayer = null;

            battleManager.createGrassTerrainMap();

            battleManager.ModifyTileTerrain(4, 4, new WaterTerrain());
            battleManager.ModifyTileTerrain(3, 3, new WallTerrain());

            player.XCoordinate = 5;
            player.YCoordinate = 5;
            enemy.XCoordinate = 15;
            enemy.YCoordinate = 5;

            battleManager.BattleField.TileArray[player.XCoordinate, player.YCoordinate].OccupyingPlayer = player;
            battleManager.BattleField.TileArray[enemy.XCoordinate, enemy.YCoordinate].OccupyingPlayer = enemy;

            //// battlefieldUi.DisplayMap();

            //battlefieldUi.UpdateMapMovement();

            //battlefield.Tile[5, 5].OccupyingPlayer.Name = "test2";

            //Console.WriteLine(player.Name);

            //BattlefieldUI test = Battlefield.;

            //            ConsoleWindow.RenderThreeColumn(
            //    left: battlefieldUi.DisplayBattleFieldLegend,   // your method that writes to Console
            //    center: battlefieldUi.DisplayMap,                 // your map renderer (Console.Write/Line)
            //    right: () =>
            //    {
            //        Console.WriteLine("Movement Options:");
            //        Console.WriteLine($"{ControlMapping.MovementUP} - Move Up");
            //        Console.WriteLine($"{ControlMapping.MovementLEFT} - Move Left");
            //        Console.WriteLine($"{ControlMapping.MovementDOWN} - Move Down");
            //        Console.WriteLine($"{ControlMapping.MovementRIGHT} - Move Right");
            //        Console.WriteLine($"{ControlMapping.ExitMenu} - Exit");
            //    },
            //    leftWidth: 28,
            //    rightWidth: 28,
            //    leftTitle: "Legend",
            //    centerTitle: "Battlefield",
            //    rightTitle: "Controls"
            //);
            SpellCasting spellCasting = new SpellCasting(new Fireball(), player, battleManager.BattleField);
            SpellCastingUi ui = new SpellCastingUi(battlefieldUi);
            spellCasting.CastSpell(ui);
            SpellCasting spellCasting2 = new SpellCasting(new Fireball(), enemy, battleManager.BattleField);
            spellCasting2.CastSpell(ui);

            //battlefieldUi.MovementMenu();

            //battlefieldUi.DisplayBattleFieldLegend();

            Console.ReadKey();
        }
    }
}