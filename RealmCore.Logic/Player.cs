using RealmCore.Logic.Characters;

namespace RealmCore.Logic
{
    public class Player
    {
        #region Fields

        private string _name;
        private Character _character;
        private int _xCoordinate;
        private int _yCoordinate;
        private Guid _id;

        #endregion Fields

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

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public Guid PlayerId
        {
            get { return _id; }
        }

        #endregion Properties

        #region Constructor

        public Player()
        {
            Name = "DefaultName";
            ChosenCharacter = new Character();
            XCoordinate = -1;
            YCoordinate = -1;
            _id = Guid.NewGuid();
        }

        public Player(string name, Character character)
        {
            Name = name;
            ChosenCharacter = character;
            XCoordinate = 1;
            YCoordinate = 1;
            _id = Guid.NewGuid();
        }

        #endregion Constructor
    }
}