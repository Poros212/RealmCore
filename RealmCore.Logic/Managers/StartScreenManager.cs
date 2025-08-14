using RealmCore.Logic.Interfaces;
using System.Collections;

namespace RealmCore.Logic.Managers
{
    class StartScreenManager
    {
        private readonly ITitleScreen _titleScreen;

        public StartScreenManager(ITitleScreen titleScreen)
        {
            _titleScreen = titleScreen;
        }


        public void DisplayStartScreen()
        {
            _titleScreen.DisplayTitle();
            _titleScreen.DisplayOptions();
        }

        public void NewOrContinue()
        {
            if (_titleScreen.IsNewGameSelected() == true)
            {
                // Start a new game
            }
            else
            {
                // Load an existing game or exit
            }
        }


    }
}

