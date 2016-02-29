using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    //Vorlage für alle Effekte
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
