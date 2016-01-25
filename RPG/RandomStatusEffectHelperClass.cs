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
            int random = new Random().Next(0, 10 * 1000) / 1000;

            List<IEffect> statusEffects = new List<IEffect>() { new Bleed(), new Bless(), new Burn(), new Damage(), new RemoveStatusEffect(), new Halo(), new Heal(), new Mindblow(), new Poison(), new AttributesChangeEffect(AttributeActions.Add, RandomAttributeHelperClass.GetRandomAttribute()), new AttributesChangeEffect(AttributeActions.Substract, RandomAttributeHelperClass.GetRandomAttribute()) };

            return statusEffects.ElementAt(random);
        }

    }
}
