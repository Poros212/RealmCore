using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;


namespace RealmCore.Logic.Effects
{
    public class DamageEffect : Effect
    {

       public DamageEffect()
        {
            EffectType = "DamageEffect";
        }

        public override void ApplyEffect(int value, int duration, Character caster, Character target)
        {
            target.CurrentHealth -= value;
        }
    }
}
