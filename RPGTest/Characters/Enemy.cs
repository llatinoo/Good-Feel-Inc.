using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest
{
    class Enemy : Character
    {
        public void UpdateStats(int _vita, int _strg, int _mag, int _def, int _mana, int _luck)
        {
            Vitality += _vita;
            Strength += _strg;
            Magic += _mag;
            Defense += _def;
            Mana += _mana;
            Luck += _luck;
        }
    }
}
