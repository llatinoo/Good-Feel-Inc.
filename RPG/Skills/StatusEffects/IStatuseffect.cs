using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public interface IStatuseffect
    {
        int Duration { get; set; }
        int Damage { get; set; }

        int ExecuteStatus();

        bool IsDone();
    }
}
