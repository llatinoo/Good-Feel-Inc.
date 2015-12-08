using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class Skill
    {
        public string Name { get; set; }
        public int Costs { get; set; }
        public IList<IEffect> effects { get; set; }

        public Skill(string skillName, int manacosts, List<IEffect> skilleffects)
        {
            this.Name = skillName;
            this.Costs = manacosts;
            this.effects = skilleffects;
        }

        public void Execute(Character source, List<Character> targets)
        {
            source.FightMana -= this.Costs;
            foreach (IEffect effect in effects)
            {
                effect.Execute(source, targets);
            }       
        }
    }
}
