using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
