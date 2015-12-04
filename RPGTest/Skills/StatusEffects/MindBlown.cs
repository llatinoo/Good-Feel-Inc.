using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class MindBlown : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            Damage = 0;

            foreach (Character target in targets)
            {
                bool exists = false;

                foreach (IStatuseffect existingStatus in target.statuseffects)
                {
                    var status = existingStatus as MindBlown;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    if (target.Level > source.Level)
                    {
                        Duration = 1;
                    }
                    else
                    {
                        Duration = source.Level - target.Level;
                    }

                    target.statuseffects.Add(this);
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
