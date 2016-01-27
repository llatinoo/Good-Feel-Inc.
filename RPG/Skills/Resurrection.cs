using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills
{
    public class Resurrection : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                if (target.Life == 0)
                {
                    target.Life = (target.FightVitality/3) + (source.FightMagic/3);
                }
            }
        }
    }
}
