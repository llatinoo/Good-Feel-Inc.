using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Wundergranate : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Burn().Execute(source, targets);
            new RandomDebuffEffect().Execute(source, targets);
            new RandomDebuffEffect().Execute(source, targets);
            new RandomEffect().Execute(source, targets);
        }
    }
}
