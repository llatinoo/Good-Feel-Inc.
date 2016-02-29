using System.Collections.Generic;

namespace RPG
{
    public class BaumDesLebens : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightResistance).Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightVitality).Execute(source, targets);
            new Heal().Execute(source, targets);
        }
    }
}
