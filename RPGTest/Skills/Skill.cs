using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class Skill
    {
        public string name ;
        public int costs;
        public IList<IEffect> effects;

        //private IEffect healEffect;
        //private IEffect criticalDamageEffect;

        //TODO Effect Liste
        public Skill(string skillName, int manacosts, List<IEffect> skilleffects)
        {
            this.name = skillName;
            this.costs = manacosts;
            this.effects = skilleffects;

            //this.healEffect = new HealEffect();
            //this.criticalDamageEffect = new CriticalDamageEffect();
        }

        public void Execute(Character source, List<Character> targets)
        {
            source.Mana -= this.costs;
            foreach (IEffect effect in effects)
            {
                effect.Execute(source, targets);
            }

            //healEffect.Execute(this.character, this.character);
            //criticalDamageEffect.Execute(this.character, target);            
        }
    }
}
