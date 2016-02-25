using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.Effects
{
    public class Recover : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            source.Mana += 40;
        }
    }
}
