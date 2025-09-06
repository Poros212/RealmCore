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

        public Validations.DtoValidationResult<Player> CreatePlayer()
        {
            string name = _playerCreationUI.EnterName();

            while (true)
            {
                string characterClass = _playerCreationUI.ChooseCharacter();

                switch (characterClass)
                {
                    case "apprentice" or "1":
                        return new Validations.DtoValidationResult<Player>
                        {
                            IsOK = true,
                            Value = new Player(name, new Apprentice())
                        };

                    default:
                        _playerCreationUI.DisplayError();
                        continue;
                }
            }
        }
    }
}