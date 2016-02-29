using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Zeitsprung : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Resurrection().Execute(source,targets);
            new Heal().Execute(source,targets);
        }
    }
}
