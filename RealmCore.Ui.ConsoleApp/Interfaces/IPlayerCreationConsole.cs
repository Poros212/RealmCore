using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Characters;

namespace RealmCore.UI.ConsoleApp.Interfaces
{
    public class IPlayerCreationConsole : IPlayerCreationUI
    {
        public string EnterName()
        {
            Console.Write("Enter your character's name: ");
            string inputName = Console.ReadLine();
            return inputName;
        }
        public string ChooseCharacter()
        {
            Console.Clear();
            Console.WriteLine("[1] Apprentice\n");
            Console.Write("Choose your character class: ");
            string playerChoice = Console.ReadLine().ToLower();
            return playerChoice;
        }
    }
}
