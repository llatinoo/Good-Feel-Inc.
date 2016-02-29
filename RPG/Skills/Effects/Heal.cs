using System;
using System.Collections.Generic;

namespace RPG
{
    public class Heal : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.Life += Convert.ToInt32(source.FightMagic);
            }
        }
    }
}