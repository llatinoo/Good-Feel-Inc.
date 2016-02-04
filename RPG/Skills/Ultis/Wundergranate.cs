using System.Collections.Generic;

namespace RPG
{
    public class Wundergranate : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Burn().Execute(source, targets);
            new RandomDebuffEffect().Execute(source, targets);
            new RandomDebuffEffect().Execute(source, targets);
            new RandomEffect().Execute(source, targets);
        }
    }
}
