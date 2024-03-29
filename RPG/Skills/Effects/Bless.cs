﻿using System.Collections.Generic;

namespace RPG.Skills.Effects
{
    public class Bless : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //Verursacht einen Statuseffekt
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Blessing(target));
        }
    }
}
