using RealmCore.Logic;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.UI.ConsoleApp.Implementations;
using RealmCore.Logic.Validations;


namespace RealmCore.UI.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IPlayerCreationUI playerCreationUI = new PlayerCreationConsoleUI();

            PlayerCreationManager playerCreationManager = new PlayerCreationManager(playerCreationUI);

            Player playerCharacter = playerCreationManager.CreatePlayer();

            Console.WriteLine($"Welcome {playerCharacter.Name}, you have chosen the {playerCharacter.ChosenCharacter.Name} class.");


            Console.WriteLine("REALMCORE");
            Console.WriteLine("New Game");
            Console.WriteLine("Continue");

          


            Console.ReadKey();

        }
    }
}
