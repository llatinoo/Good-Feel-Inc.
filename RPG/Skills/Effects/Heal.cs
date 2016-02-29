using System;
using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class Heal : IEffect
    {
        //Heilt das Ziel
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                if (target.Life != 0)
                {
                    target.Life += Convert.ToInt32(source.FightMagic);
                }
            }
        }
    }
}