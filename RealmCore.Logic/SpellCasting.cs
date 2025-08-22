using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmCore.Logic.Interfaces;
using RealmCore.Logic.Maps;
using RealmCore.Logic.Spells;

using RealmCore.Logic.Tiles;

namespace RealmCore.Logic
{
    public class SpellCasting
    {
        public Spell Spell { get; set; }
        public Player Caster { get; set; }
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
        public BattleField BattleField { get; set; }

        public SpellCasting(Spell spell, Player caster, BattleField battlefield)
        {
            Spell = spell;
            Caster = caster;
            BattleField = battlefield;
        }

        public void CastSpell(ISpellCast spellCast)
        {
            Caster.ChosenCharacter.CurrentMana -= Spell.ManaCost;

            int StartingX = Caster.XCoordinate;
            int StartingY = Caster.YCoordinate;

            while (true)
            {
                for (int i = Caster.XCoordinate; i < Spell.XRange; i++)
                {
                    var spellLocation = BattleField.TileArray[i, Caster.YCoordinate];

                    spellCast.DisplaySpellTravel(i, Caster.YCoordinate);

                    if (spellLocation.OccupyingPlayer != null && spellLocation.OccupyingPlayer != Caster)
                    {
                        Console.WriteLine("hit");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }
}