using RealmCore.Logic.Characters;
using RealmCore.Logic.Effects;

namespace RealmCore.Logic.Spells
{
    public abstract class Spell
    {
        #region Fields

        private string _name;
        private string _description;
        private int _manaCost;
        private Effect _effect;
        private int _effectValue;
        private int _duration;
        private Guid _id;

        #endregion Fields

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value; }
        }

        public Effect Effect
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public int EffectValue
        {
            get { return _effectValue; }
            set { _effectValue = value; }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string AreaOfEffect { get; set; }

        public int XRange { get; set; } = 1;
        public int YRange { get; set; } = 1;

        #endregion Properties

        #region Constructor

        public Spell()
        {
            Name = "DefaultSpell";
            Description = "This is a default spell description.";
            ManaCost = 0;
            Effect = null;
            EffectValue = 0;
            Duration = 0;
            Id = Guid.NewGuid();
            AreaOfEffect = "Single";
            XRange = 1;
            YRange = 1;
        }

        public abstract void CastSpell(Character caster, Character target);

        #endregion Constructor
    }
}