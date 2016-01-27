using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Shcmetterschlag : IEffect
    {
        private Random r1;
        public void Execute(Character source, List<Character> targets)
        {
            new Damage().Execute(source, targets);
            new Damage().Execute(source, targets);
            new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightDefense).Execute(source, targets);
            foreach (var target in targets)
            {
                if (this.r1.Next(0,101 * 1000) / 1000 <= 40)
                {
                    new Mindblow().Execute(source, new List<Character>() {target});
                }
            }
        }
    }
}
