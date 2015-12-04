using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
