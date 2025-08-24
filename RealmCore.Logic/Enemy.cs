using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Characters;

namespace RealmCore.Logic
{
    public class Enemy : Player
    {
        public Enemy(string name, Character character)
        {
            Name = name;
            ChosenCharacter = character;
        }
    }
}