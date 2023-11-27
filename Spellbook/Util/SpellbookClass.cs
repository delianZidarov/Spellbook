using System;
using System.Collections.Generic;

using Spellbook.Util;

namespace Spellbook.Util
{
    public class SpellBook
    {
        Dictionary<string, Spell> _contents = new Dictionary<string, Spell>();

        public void Add(Spell newSpell)
        {
            try
            {

                _contents.Add(newSpell.Name, newSpell);
            }
            catch
            {
                Console.WriteLine("Spell already exists");
            }
        }

        public void Delete(string spellName)
        {
            _contents.Remove(spellName);
        }

        public Spell getSpell(string spellName)
        {
            return _contents[spellName];
        }

        public LinkedList<string> getCastableSpells(int highestAvailableSlot)
        {
            LinkedList<string> spells = new LinkedList<string>();
            //Clean
            string s = "";
            foreach (KeyValuePair<string, Spell> spell in _contents)
            {
                if (spell.Value.Level <= highestAvailableSlot)
                {
                    spells.AddLast(spell.Value.Name);
                    //Clean
                    s += spell.Value.Name + ", ";
                }

            }
            //Clean
            Console.WriteLine(s);
            return spells;
        }

        public void printSpell(string spellName)
        {
            Spell selectedSpell = _contents[spellName];
            Console.WriteLine(selectedSpell.Name);
            Console.WriteLine("Level: " + selectedSpell.Level);
            Console.WriteLine("Range: " + selectedSpell.Range);
            Console.WriteLine("Target: " + selectedSpell.Target);
            Console.WriteLine("Description: " + selectedSpell.Description);
            Console.WriteLine("Damage: " + selectedSpell.Damage);
        }
    }

}

