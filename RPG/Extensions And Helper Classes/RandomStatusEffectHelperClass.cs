using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Skills.Effects;

namespace RPG
{
    public static class RandomStatusEffectHelperClass
    {
        //Gibt einen zufälligen Statuseffekt zurück
        public static IEffect  GetRandomStatuseffect()
        {
            List<IEffect> statusEffects = new List<IEffect>() { new Bleed(), new Bless(), new Burn(), new Damage(), new Halo(), new Heal(), new Mindblow(), new Poison(), new AttributesChangeEffect(AttributeActions.Add, RandomAttributeHelperClass.GetRandomAttribute()), new AttributesChangeEffect(AttributeActions.Substract, RandomAttributeHelperClass.GetRandomAttribute()) };
            int random = new Random().Next(0, statusEffects.Count * 1000) / 1000;

            return statusEffects.ElementAt(random);
        }

        //Gibt einen zufälligen positiven Statuseffekt zurück
        public static IEffect GetRandomBuffEffect()
        {
            List<IEffect> buffEffects = new List<IEffect>() {new Bless(), new Halo(), new Heal(), new AttributesChangeEffect(AttributeActions.Add, RandomAttributeHelperClass.GetRandomAttribute()) };
            int random = new Random().Next(0, buffEffects.Count * 1000) / 1000;

            return buffEffects.ElementAt(random);
        }

        //Gibt einen zufälligen negativen Statuseffekt zurück
        public static IEffect GetRandomDebuffEffect()
        {
            List<IEffect> debuffEffects = new List<IEffect>() { new Bleed(), new Burn(), new Damage(), new Mindblow(), new Poison(), new AttributesChangeEffect(AttributeActions.Substract, RandomAttributeHelperClass.GetRandomAttribute()) };
            int random = new Random().Next(0, debuffEffects.Count * 1000) / 1000;

            return debuffEffects.ElementAt(random);
        }
    }
}
