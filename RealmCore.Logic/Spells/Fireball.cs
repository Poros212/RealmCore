using RealmCore.Logic.Characters;
using RealmCore.Logic.Effects;

namespace RealmCore.Logic.Spells
{
    public class Fireball : Spell
    {
        #region Constructor

        public Fireball()
        {
            Name = "FireBall";
            Description = "Throw a flaming ball of fire at the enemy";
            ManaCost = 3;
            EffectValue = 1;
            //Effect = DamageEffect;
            Duration = 1;
            Id = Guid.NewGuid();
            AreaOfEffect = "Single";
            XRange = 99;
            YRange = 99;
        }

        public override void CastSpell(Character caster, Character target)
        {
            DamageEffect.Instance.ApplyEffect(EffectValue, Duration, caster, target);
        }

        #endregion Constructor
    }
}