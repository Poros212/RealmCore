using RealmCore.Logic.Characters;

namespace RealmCore.Logic.Effects
{
    public interface IEffect
    {
        public abstract void ApplyEffect(int value, int duration, Character caster, Character target);
    }
}