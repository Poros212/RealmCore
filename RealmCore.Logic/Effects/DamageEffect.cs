using RealmCore.Logic.Characters;

namespace RealmCore.Logic.Effects
{
    public sealed class DamageEffect : IEffect
    {
        public static DamageEffect Instance { get; } = new DamageEffect();

        private DamageEffect()
        { }

        public void ApplyEffect(int value, int duration, Character caster, Character target)
        {
            target.CurrentHealth -= value;
        }
    }
}