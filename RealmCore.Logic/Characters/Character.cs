using RealmCore.Logic.Spells;

namespace RealmCore.Logic.Characters
{
    public class Character
    {
        #region Fields

        private string _name;
        private int _maxHealth;
        private int _currentHealth;
        private int _maxMana;
        private int _currentMana;
        private int _intelligence;
        private int _defense;
        private int _resistance;
        private List<Spell> _spellPool;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }
        public int MaxMana
        {
            get { return _maxMana; }
            set { _maxMana = value; }
        }
        public int CurrentMana
        {
            get { return _currentMana; }
            set { _currentMana = value; }
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }
        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int Resistance
        {
            get { return _resistance; }
            set { _resistance = value; }
        }
        public List<Spell> SpellPool
        {
            get { return _spellPool; }
            set { _spellPool = value; }
        }

        #endregion

        #region Constructor

        public Character()
        {
            Name = "DefaultCharacterName";
            MaxHealth = 1;
            CurrentHealth = 1;
            MaxMana = 0;
            CurrentMana = 0;
            Intelligence = 0;
            Defense = 0;
            Resistance = 0;
            SpellPool = new List<Spell>();
        }

        #endregion
    }
}
