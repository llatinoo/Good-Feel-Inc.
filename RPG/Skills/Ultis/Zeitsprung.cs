using System.Collections.Generic;

namespace RPG
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
