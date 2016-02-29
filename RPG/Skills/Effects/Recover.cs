using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class Recover : IEffect
    {
        //Der Effekt für die zweite Standard-Fähigkeit
        //Zurückgewinnen von Mana
        public void Execute(Character source, List<Character> targets)
        {
            source.Mana += 40;
        }
    }
}
