using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Woog : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightResistance).Execute(source, targets);
            new Bleed().Execute(source,targets);
            new Poison().Execute(source,targets);
            new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightStrength).Execute(source,targets);
        }
    }
}
