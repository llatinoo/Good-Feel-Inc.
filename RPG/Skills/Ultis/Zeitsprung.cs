using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills.Ultis
{
    public class Zeitsprung : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Resurrection().Execute(source,targets);
            new Heal().Execute(source,targets);
        }
    }
}
