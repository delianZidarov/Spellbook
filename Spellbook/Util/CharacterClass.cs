using System;
using System.Collections.Generic;
using Spellbook.Util;

namespace Spellbook.Util
{
    public class Character
    {
        private int[] _availableSpellSlots = new int[9];
        private int _casterLevel = 0;
        private SpellBook _spellBook = new SpellBook();

        public Character(Tuple<string, int>[] classes)
        {
            int cLevel = 0;

            foreach (Tuple<string, int> charClass in classes)
            {
                if (charClass.Item1 == "Bard" ||
                    charClass.Item1 == "Cleric" ||
                    charClass.Item1 == "Druid" ||
                    charClass.Item1 == "Sorcerer" ||
                    charClass.Item1 == "Wizard")
                {
                    cLevel += charClass.Item2;
                }

                if (charClass.Item1 == "Paladin" ||
                    charClass.Item1 == "Ranger")
                {
                    cLevel += charClass.Item2 / 2;
                }
                if (charClass.Item1 == "Artificer")
                {
                    cLevel += (int)Math.Ceiling((double)charClass.Item2 / 2);
                }
                if (charClass.Item1 == "Arcane Trickster" ||
                    charClass.Item1 == "Eldritch Knight")
                {
                    cLevel += charClass.Item2 / 3;
                }
            }
            _casterLevel = cLevel;
            Reset();
        }
        // End constructor

        //SpellSlot Manipulation
        public void Cast(int level)
        {
            _availableSpellSlots[level - 1] -= 1;
        }
        public void Regain(int level)
        {
            _availableSpellSlots[level - 1] += 1;
        }
        public int[] GetAvailableSpellSlots()
        {
            return _availableSpellSlots;
        }
        public void SetAvailablleSpellSlots(int[] spellSlots)
        {
            _availableSpellSlots = spellSlots;
        }
        public void Reset()
        {

            if (_casterLevel > 0)
            {

                // 1st level spell calc
                if (_casterLevel > 2)
                {
                    _availableSpellSlots[0] = 4;
                }
                else
                {
                    _availableSpellSlots[0] = _casterLevel + 1;
                }

                //2nd level spell calc
                if (_casterLevel > 3)
                {
                    _availableSpellSlots[1] = 3;
                }
                else if (_casterLevel == 3)
                {
                    _availableSpellSlots[1] = 2;
                }

                //3rd level spell calc 
                if (_casterLevel > 5)
                {
                    _availableSpellSlots[2] = 3;
                }
                else if (_casterLevel == 5)
                {
                    _availableSpellSlots[2] = 2;
                }

                //4th level spell calc
                if (_casterLevel > 8)
                {
                    _availableSpellSlots[3] = 3;
                }
                else if (_casterLevel > 6)
                {
                    _availableSpellSlots[3] = _casterLevel - 6;
                }

                //5th  level spell calc
                if (_casterLevel > 17)
                {
                    _availableSpellSlots[4] = 3;
                }
                else if (_casterLevel > 9)
                {
                    _availableSpellSlots[4] = 2;
                }
                else if (_casterLevel == 9)
                {
                    _availableSpellSlots[4] = 1;
                }

                //6th level spell calc
                if (_casterLevel > 18)
                {
                    _availableSpellSlots[5] = 2;
                }
                else if (_casterLevel > 10)
                {
                    _availableSpellSlots[5] = 1;
                }

                //7th level spell calc
                if (_casterLevel == 20)
                {
                    _availableSpellSlots[6] = 2;
                }
                else if (_casterLevel > 12)
                {
                    _availableSpellSlots[6] = 1;
                }
                //8th level spell calc
                if (_casterLevel > 14)
                {
                    _availableSpellSlots[7] = 1;
                }
                //9th level spell calc
                if (_casterLevel > 16)
                {
                    _availableSpellSlots[8] = 1;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Spell Level: " + (i + 1) + " " + "Spell Slots: " + _availableSpellSlots[i]);
            }
        }


        //SpellBook manipulation
        public void AddSpell(Spell spell)
        {
            _spellBook.Add(spell);
        }

        public void RemoveSpell(string name)
        {
            _spellBook.Delete(name);
        }

        public LinkedList<string> GetAvailableSpells()
        {
            int highestAvailableSpellLevel = 0;
            for (int i = 8; i >= 0; i--)
            {

                if (_availableSpellSlots[i] > 0)
                {
                    highestAvailableSpellLevel = i + 1;
                    break;
                }
            }
            return _spellBook.getCastableSpells(highestAvailableSpellLevel);
        }

        public Spell GetSpell(string name)
        {
            return _spellBook.getSpell(name);
        }
    }
}


