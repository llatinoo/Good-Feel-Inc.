using RPG.Characters;
using System.Collections.Generic;

namespace RPG.Skills
{
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
