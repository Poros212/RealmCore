using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Texts;
using RealmCore.Logic.Validations;


namespace RealmCore.UI.ConsoleApp.Implementations
{
    public class PlayerCreationConsoleUI : IPlayerCreationUI
    {
        public string EnterName()
        {
            while (true)
            {
                Console.Write(PlayerCreationTexts.EnterName);

                string? inputName = Console.ReadLine();

                ValidationResultDto<string> validation = StringInputValidator.CheckStringInput(inputName);

                if (validation.IsOK)
                {
                    return validation.Value!;
                }
                
                UiFormat.DisplayError(validation.ErrorMessage!);
            }
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
