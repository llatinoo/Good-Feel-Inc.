using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public interface IEffect
    {
        IStatuseffect Statuseffect { get; set; }

        void Execute(Character source, List<Character> targets);
    }
}
