using RealmCore.Logic.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealmCore.Logic.SnapShots
{
    public class SnapshotCharacter
    {
        public string Name { get; }
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        public int MaxMana { get; }
        public int CurrentMana { get; }
        public int Intelligence { get; }
        public int Defense { get; }
        public int Resistance { get; }
        public List<Spell> SpellPool { get; }
        public int MaxMovementPoints { get; }
        public int CurrentMovementPoints { get; }
        public int Speed { get; }

        public SnapshotCharacter(string name, int maxHealth, int currentHealth, int maxMana, int currentMana, int intelligence, int defense, int resistance, List<Spell> spellPool, int maxMovementPoints, int currentMovementPoints, int speed)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            MaxMana = maxMana;
            CurrentMana = currentMana;
            Intelligence = intelligence;
            Defense = defense;
            Resistance = resistance;
            SpellPool = spellPool;
            MaxMovementPoints = maxMovementPoints;
            CurrentMovementPoints = currentMovementPoints;
            Speed = speed;
        }
    }
}