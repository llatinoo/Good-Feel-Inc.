﻿using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Fegefeuer : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            new Damage().Execute(source, targets);
            new Damage().Execute(source, targets);
            new Burn().Execute(source, targets);
        }
    }
}
