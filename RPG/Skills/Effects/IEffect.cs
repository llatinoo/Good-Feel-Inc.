using System.Collections.Generic;

namespace RPG
{
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
