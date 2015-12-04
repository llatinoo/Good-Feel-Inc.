using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public interface IStatuseffect : IEffect
    {
        int Duration { get; set; }
        int Damage { get; set; }

        bool IsDone();
    }
}
