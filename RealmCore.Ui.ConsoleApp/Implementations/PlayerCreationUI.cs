using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Texts;
using RealmCore.Logic.Validations;
using RealmCore.UI.ConsoleApp.Map;

namespace RealmCore.UI.ConsoleApp.Implementations
{
    public class PlayerCreationUI : IPlayerCreationUI
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
                return Console.ReadLine().ToLower();
                //string playerChoice = Console.ReadLine().ToLower();
                //if (playerChoice == "1" || playerChoice == "apprentice")
                //{
                //    return playerChoice;
                //}
                //UiFormat.DisplayError(PlayerCreationTexts.InvalidChoice);
            }
        }

        public void DisplayError()
        {
            UiFormat.DisplayError(PlayerCreationTexts.InvalidChoice);
        }
    }
}