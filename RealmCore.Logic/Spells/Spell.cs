using RealmCore.Logic.Characters;
using RealmCore.Logic.Effects;

namespace RealmCore.Logic.Spells
{
    public abstract class Spell
    {
        #region Properties

        public string Name
        {
            get;
            init;
        }

        public string Description
        {
            get;
            init;
        }

        public int ManaCost
        {
            get; init;
        }

        public Effect Effect
        {
            get; init;
        }

        public int EffectValue
        {
            get; init;
        }

        public int Duration
        {
            get; init;
        }

        public Guid Id
        {
            get; init;
        }

        public string AreaOfEffect { get; init; }

        public int XRange { get; init; }
        public int YRange { get; init; }

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

        public Spell(string name, string description, int manaCost, Effect effect, int effectValue, int duration, Guid? guid = null, string areaOfEffect, int xRange, int yRange)
        {
            Name = name;
            Description = description;
            ManaCost = manaCost;
            Effect = effect;
            EffectValue = effectValue;
            Duration = duration;
            Id = Guid.NewGuid();
            AreaOfEffect = areaOfEffect;
            XRange = xRange;
            YRange = yRange;
        }

        public abstract void CastSpell(Character caster, Character target);

        #endregion Constructor
    }
}