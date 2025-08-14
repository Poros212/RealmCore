using RealmCore.Logic.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void UiPressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(GeneralTexts.PressAnyKeyToContinue);
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
