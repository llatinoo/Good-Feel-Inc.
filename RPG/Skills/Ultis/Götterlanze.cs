﻿using System.Collections.Generic;

namespace RPG
{
    public class Götterlanze : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Damage().Execute(source, targets);
            new Damage().Execute(source, targets);
            new Damage().Execute(source, targets);
        }
    }
}
