using RealmCore.Logic;
using RealmCore.Logic.Characters;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Tiles;
using RealmCore.Logic.Tiles.Terrains;
using RealmCore.Logic.Validations;
using RealmCore.UI.ConsoleApp.Implementations;
using Spectre.Console;
using System.Runtime.InteropServices;
using RealmCore.Logic.Controls;
using RealmCore.Logic.Spells;
using RealmCore.Logic.Battle;

namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Enemy> enemies = new List<Enemy>();

            Player player1 = new Player("Hero", new Apprentice());
            players.Add(player1);

            Enemy enemy1 = new Enemy("Goblin", new Apprentice());
            enemies.Add(enemy1);

            BattleField battleField = new BattleField(15, 15);
            BattleContext battleContext = new BattleContext(players, enemies, battleField);
            BattleManager battleManager = new BattleManager(battleContext, null);
            BattlefieldUI battlefieldUI = new BattlefieldUI(battleManager);
            battleManager.BattlefieldImplementation = battlefieldUI;

            battleManager.StartBattle();

            Console.ReadKey();
        }
    }
}