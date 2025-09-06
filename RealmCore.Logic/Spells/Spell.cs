using RealmCore.Logic.Characters;
using RealmCore.Logic.Effects;

namespace RealmCore.Logic.Spells
{
    /// <summary>
    /// Represents the abstract base class for all spells in the game.
    /// Encapsulates common properties and behavior for spells.
    /// </summary>
    public abstract class Spell
    {
        #region Properties

        /// <summary>
        /// Gets the name of the spell.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets the description of the spell.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Gets the mana cost required to cast the spell.
        /// </summary>
        public int ManaCost { get; init; }

        ///// <summary>
        ///// Gets the effect associated with the spell.
        ///// </summary>
        //public IEffect? Effect { get; init; }

        /// <summary>
        /// Gets the value of the effect (e.g., damage, healing amount).
        /// </summary>
        public int EffectValue { get; init; }

        /// <summary>
        /// Gets the duration of the spell's effect in turns.
        /// </summary>
        public int Duration { get; init; }

        /// <summary>
        /// Gets the unique identifier for the spell.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the area of effect description for the spell.
        /// </summary>
        public string? AreaOfEffect { get; init; }

        /// <summary>
        /// Gets the X range of the spell's area of effect.
        /// </summary>
        public int XRange { get; init; }

        /// <summary>
        /// Gets the Y range of the spell's area of effect.
        /// </summary>
        public int YRange { get; init; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Spell"/> class with the specified parameters.
        /// </summary>
        public Spell()
        {
            Name = "DefaultSpell";
            Description = "DefaultDesc";
            ManaCost = 0;
            //Effect = null;
            EffectValue = 0;
            Duration = 0;
            Id = Guid.NewGuid();
            AreaOfEffect = null;
            XRange = 0;
            YRange = 0;
        }

        #endregion Constructor

        /// <summary>
        /// Casts the spell from the caster to the target.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <param name="caster">The character casting the spell.</param>
        /// <param name="target">The character targeted by the spell.</param>
        public abstract void CastSpell(Character caster, Character target);
    }
}