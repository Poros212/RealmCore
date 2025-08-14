using RealmCore.Logic.Characters;

namespace RealmCore.Logic
{
    public class Player
    {
        #region Fields

        private string _name;
        private Character _character;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Character ChosenCharacter
        {
            get { return _character; }
            set { _character = value; }
        }

        #endregion

        #region Constructor

        public Player()
        {
            Name = "DefaultName";
            ChosenCharacter = new Character();
        }
        public Player(string name, Character character)
        {
            Name = name;
            ChosenCharacter = character;
        }

        #endregion
    }
}
