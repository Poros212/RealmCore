using RealmCore.Logic.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;

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
            Effect = new DamageEffect();
            EffectValue = 2;
            Duration = 1;
            Id = Guid.NewGuid();
        }

        public override void CastSpell(Character caster, Character target)
        {
            Effect.ApplyEffect(EffectValue, Duration, caster, target);
        }

        #endregion
    }
}
