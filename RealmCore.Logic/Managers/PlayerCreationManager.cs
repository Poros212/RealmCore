using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;
using RealmCore.Logic.Interfaces;

namespace RealmCore.Logic.Managers
{
    public class PlayerCreationManager
    {
        private readonly IPlayerCreationUI _playerCreationUI;

        public PlayerCreationManager(IPlayerCreationUI ui)
        {
            _playerCreationUI = ui;
        }

        public Player CreatePlayer()
        {
            string name = _playerCreationUI.EnterName();

            while (true)
            {
                string characterClass = _playerCreationUI.ChooseCharacter();

                switch (characterClass)
                {
                    case "apprentice":
                        return new Player(name, new Apprentice());
                    case "1":
                        return new Player(name, new Apprentice());
                    default:
                        continue;
                }               
            }

        }
    }
}
