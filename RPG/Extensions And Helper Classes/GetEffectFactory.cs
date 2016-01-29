using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Skills.Effects;

namespace RPG.Extensions_And_Helper_Classes
{
    public static class GetEffectFactory
    {
        public static IEffect GetEffect(string effectName)
        {
            //Attributes Change
            //Vit
            if (effectName.ToLower() == "VitalityBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightVitality);

            if (effectName.ToLower() == "VitalityDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightVitality);

            //Man
            if (effectName.ToLower() == "ManaBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightManaPool);

            if (effectName.ToLower() == "ManaDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightManaPool);

            //Strg
            if (effectName.ToLower() == "StrengthBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightStrength);

            if (effectName.ToLower() == "StrengthDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightStrength);

            //Mag
            if (effectName.ToLower() == "MagicBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightMagic);

            if (effectName.ToLower() == "MagicDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightMagic);

            //Def
            if (effectName.ToLower() == "DefenseBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightDefense);

            if (effectName.ToLower() == "DefenseDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightDefense);

            //Res
            if (effectName.ToLower() == "ResistanceBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightResistance);

            if (effectName.ToLower() == "ResistanceDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightResistance);

            //Luck
            if (effectName.ToLower() == "LuckBuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Add, Attributes.FightLuck);

            if (effectName.ToLower() == "LuckDebuff".ToLower())
                return new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightLuck);

            //Bleed
            if (effectName.ToLower() == "Bleed".ToLower())
                return new Bleed();

            //Bless
            if (effectName.ToLower() == "Bless".ToLower())
                return new Bless();

            //Burn
            if (effectName.ToLower() == "Burn".ToLower())
                return new Burn();

            //CriticalDamage
            if (effectName.ToLower() == "CriticalDamage".ToLower())
                return new CriticalDamage();

            //Damage
            if (effectName.ToLower() == "Damage".ToLower())
                return new Damage();

            //Drain
            if (effectName.ToLower() == "Drain".ToLower())
                return new Drain();

            //Halo
            if (effectName.ToLower() == "Halo".ToLower())
                return new Halo();

            //Heal
            if (effectName.ToLower() == "Heal".ToLower())
                return new Heal();

            //Mindblow
            if (effectName.ToLower() == "Mindblow".ToLower())
                return new Mindblow();

            //Poison
            if (effectName.ToLower() == "Poison".ToLower())
                return new Poison();

            //RandomBuff
            if (effectName.ToLower() == "RandomBuff".ToLower())
                return new RandomBuffEffect();

            //RandomDebuff
            if (effectName.ToLower() == "RandomDebuff".ToLower())
                return new RandomDebuffEffect();

            //RandomEffect
            if (effectName.ToLower() == "RandomEffect".ToLower())
                return new RandomEffect();

            //RemoveStatus
            if (effectName.ToLower() == "RemoveStatus".ToLower())
                return new RemoveStatusEffect();

            //Resurrection
            if (effectName.ToLower() == "Resurrection".ToLower())
                return new Resurrection();
            else
            {
                return null;
            }
        }
    }
}
