using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;

namespace RealmCore.Logic.Effects
{
    public abstract class Effect
    {
        #region Fields

        private string _effectType; // e.g., damage, heal, buff, debuff

        #endregion

        #region Properties

        public string EffectType
        {
            get { return _effectType; }
            set { _effectType = value; }
        }

        #endregion

        public abstract void ApplyEffect(int value, int duration, Character caster, Character target);

    }
}
