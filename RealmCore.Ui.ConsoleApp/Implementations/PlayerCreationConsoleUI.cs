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
            while (true)
            {
                Console.Clear();
                Console.WriteLine(PlayerCreationTexts.CharacterOptions);
                Console.WriteLine();
                Console.Write(PlayerCreationTexts.ChooseCharacter);
                string playerChoice = Console.ReadLine().ToLower();


                if (playerChoice == "1" || playerChoice == "apprentice")
                {
                    return playerChoice;
                }
                UiFormat.DisplayError(PlayerCreationTexts.InvalidChoice);
            }

        }
       

    }
}
