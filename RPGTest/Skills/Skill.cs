using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class Skill
    {
        public string name ;
        public int magic;
        public int strength;
        public int mana;


        public List<IEffect> effects;

        //TODO Effect Liste
        public Skill(string name, IEffect newEffect)
        {
            this.name = name;
            this.AddEffect(newEffect);
        }

        public Result Execute()
        {
            Result result = new Result(); 
            foreach (IEffect effect in effects)
            {
                effect.Execute(magic, strength, ref result);
            }

            return result;
        }

        public void AddEffect(IEffect newEffect)
        {
            effects.Add(newEffect);
        }
    }
}
