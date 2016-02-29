using System.Collections.Generic;

namespace RPG
{
    public class Fegefeuer : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Damage().Execute(source, targets);
            new Damage().Execute(source, targets);
            new Burn().Execute(source, targets);
        }
    }
}
