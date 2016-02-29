using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class Resurrection : IEffect
    {
        //Wiederbelebung eines Charakters
        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                if (target.Life == 0)
                {
                    target.Life = (target.FightVitality/3) + (source.FightMagic/3);
                }
            }
        }
    }
}
