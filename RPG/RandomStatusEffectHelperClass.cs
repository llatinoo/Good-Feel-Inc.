using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;
using RPG.Skills;
using RPG.Skills.StatusEffects;

namespace RPG
{
    public static class RandomStatusEffectHelperClass
    {
        public static IEffect GetRandomStatuseffect()
        {
            int random = new Random().Next(0, 9 * 1000) / 1000;

            List<IEffect> statusEffects = new List<IEffect>() { new Bleed(), new Bless(), new Burn(), new Damage(), new Halo(), new Heal(), new Mindblow(), new Poison(), new AttributesChangeEffect(AttributeActions.Add, RandomAttributeHelperClass.GetRandomAttribute()), new AttributesChangeEffect(AttributeActions.Substract, RandomAttributeHelperClass.GetRandomAttribute()) };

            return statusEffects.ElementAt(random);
        }

        public static IEffect GetRandomBuffEffect()
        {
            int random = new Random().Next(0, 3 * 1000) / 1000;

            List<IEffect> buffEffects = new List<IEffect>() {new Bless(), new Halo(), new Heal(), new AttributesChangeEffect(AttributeActions.Add, RandomAttributeHelperClass.GetRandomAttribute()) };

            return buffEffects.ElementAt(random);
        }

        public static IEffect GetRandomDebuffEffect()
        {
            int random = new Random().Next(0, 5 * 1000) / 1000;

            List<IEffect> debuffEffects = new List<IEffect>() { new Bleed(), new Burn(), new Damage(), new Mindblow(), new Poison(), new AttributesChangeEffect(AttributeActions.Substract, RandomAttributeHelperClass.GetRandomAttribute()) };

            return debuffEffects.ElementAt(random);
        }
    }
}
