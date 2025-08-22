using RealmCore.Logic.Texts;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace RealmCore.UI.ConsoleApp
{
    public static class UiFormat
    {
        public static void DisplayError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{text}\n");
            Console.ResetColor();
            UiPressAnyKey();
        }

        public static void UiPressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(GeneralTexts.PressAnyKeyToContinue);
            Console.ResetColor();
            Console.ReadKey(true);
            AnsiConsole.Clear();
        }
    }
}