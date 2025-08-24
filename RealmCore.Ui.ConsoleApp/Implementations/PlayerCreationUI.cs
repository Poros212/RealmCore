using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Managers;
using RealmCore.Logic.Texts;
using RealmCore.Logic.Validations;

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
            Console.Clear();
            Console.WriteLine(PlayerCreationTexts.CharacterOptions);
            Console.WriteLine();
            Console.Write(PlayerCreationTexts.ChooseCharacter);
            return Console.ReadLine().ToLower();
        }

        public void DisplayError()
        {
            UiFormat.DisplayError(PlayerCreationTexts.InvalidChoice);
        }
    }
}