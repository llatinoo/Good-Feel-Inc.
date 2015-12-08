using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Blessing : IEffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                bool exists = false;

                foreach (IStatuseffect existingStatus in target.statuseffects)
                {
                    var status = existingStatus as Blessing;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if(!exists)
                {
                    Duration = 1;
                    Damage = 0;
                }
            }
        }

        public bool IsDone()
        {
            if (Duration <= 0)
                return true;
            else
                return false;
        }
    }
}
