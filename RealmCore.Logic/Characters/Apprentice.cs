using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Spells;

namespace RealmCore.Logic.Characters
{
    public class Apprentice : Character
    {
        public Apprentice() 
        {
            Name = "Apprentice";
            MaxHealth = 20;
            CurrentHealth = 20;
            MaxMana = 10;
            CurrentMana = 10;
            SpellPool.Add(new Fireball()); 
        }        
    }
}
