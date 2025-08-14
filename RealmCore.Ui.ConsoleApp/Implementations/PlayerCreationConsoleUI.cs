using RealmCore.Logic.Interfaces;

namespace RealmCore.UI.ConsoleApp.Implementations
{
    public class PlayerCreationConsoleUI : IPlayerCreationUI
    {
        public string EnterName()
        {
            Console.Write("Enter your character's name: ");

            string inputName = Console.ReadLine();

            while (inputName.Length > 25 || string.IsNullOrWhiteSpace(inputName))
            {
                Console.Write("Name cannot be empty or exceed 25 characters. Please enter a valid name: ");
                inputName = Console.ReadLine();
            }

            return inputName;
        }
        public string ChooseCharacter()
        {
            Console.Clear();
            Console.WriteLine("[1] Apprentice\n");
            Console.Write("Choose your character class: ");
            string playerChoice = Console.ReadLine().ToLower();

            while (true)
            {
                if (playerChoice == "1" || playerChoice == "apprentice")
                {
                    return playerChoice;
                }


                Console.Write("Invalid choice. Please choose a valid character class: ");
                playerChoice = Console.ReadLine().ToLower();
            }

        }
    }
}
