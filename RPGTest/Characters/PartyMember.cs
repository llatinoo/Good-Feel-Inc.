using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest
{
    class PartyMember : Character
    {
        public int fVitality;
        public int fStrength;
        public int fMagic;
        public int fDefense;
        public int fMana;
        public int fLuck;

        public int exp;
        public List<int> levelcap;

        public List<Skills.Skill> skills;

        //TODO .BASE
        public void UpdateStats(int _vita, int _strg, int _mag, int _def, int _mana, int _luck)
        {
            fVitality += _vita;
            fStrength += _strg;
            fMagic += _mag;
            fDefense += _def;
            fMana += _mana;
            fLuck += _luck;
        }
    }
}
