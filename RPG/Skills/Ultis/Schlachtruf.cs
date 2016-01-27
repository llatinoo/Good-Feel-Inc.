using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Schlachtruf : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightVitality).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightManaPool).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightStrength).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightMagic).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightDefense).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightResistance).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightLuck).Execute(source, targets);
        }
    }
}
