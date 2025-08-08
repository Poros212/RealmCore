using RealmCore.Logic;
using RealmCore.Logic.Characters;
using RealmCore.Logic.Spells;
using RealmCore.Logic.Effects;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Interfaces;
using RealmCore.UI.ConsoleApp.Implementations;


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



            Console.ReadKey();

        }
    }
}
