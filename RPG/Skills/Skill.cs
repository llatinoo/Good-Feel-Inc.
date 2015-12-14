﻿using RPG.Characters;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Skill
    {
        public string Name { get; set; }
        public int Manacosts { get; set; }

        //Liste von Effekten die der Skill verursacht
        public IEnumerable<IEffect> Effects { get; set; }

        public Skill(string skillName, int manacosts, IEnumerable<IEffect> skilleffects)
        {
            this.Name = skillName;
            this.Manacosts = manacosts;
            this.Effects = skilleffects;
        }

        //Ausführung des Skills
        public void Execute(Character source, List<Character> targets)
        {
            //Führt alle Effekte des Skills aus
            source.FightMana -= this.Manacosts;
            foreach (IEffect effect in this.Effects)
            {
                effect.Execute(source, targets);
            }       
        }
    }
}
