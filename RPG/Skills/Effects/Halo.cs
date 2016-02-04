﻿using System.Collections.Generic;

namespace RPG
{
    public class Halo : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new HasHalo(target));
        }
    }
}
