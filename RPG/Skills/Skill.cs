﻿using System.Collections.Generic;

namespace RPG
{
    public class Skill
    {
        public string Name { get; private set; }
        public int Manacosts { get; private set; }
        public Animation Animation { get; private set; }

        //Liste von Effekten die der Skill verursacht
        public IEnumerable<IEffect> Effects { get; set; }

        public Skill(string skillName, int manacosts, IEnumerable<IEffect> skilleffects)
        {
            this.Name = skillName;
            this.Manacosts = manacosts;
            this.Effects = skilleffects;
        }

        //Ausführung des ClassSkills
        public void Execute(Character source, List<Character> targets)
        {
            //Führt alle Effekte des ClassSkills aus
            source.Mana -= this.Manacosts;
            foreach (IEffect effect in this.Effects)
            {
                effect.Execute(source, targets);
            }       
        }

        public void SetAnimation(Animation animation)
        {
            this.Animation = animation;
        }
    }
}