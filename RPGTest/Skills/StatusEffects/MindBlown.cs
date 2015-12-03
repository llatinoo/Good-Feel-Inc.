using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills.StatusEffects
{
    public class MindBlown : IStatuseffect
    {
        public int duration { get; set; }
        public int damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            damage = 0;

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
                    if (target.level > source.level)
                    {
                        duration = 1;
                    }
                    else
                    {
                        duration = source.level - target.level;
                    }

                    target.statuseffects.Add(this);
                }
            }
        }

        public bool IsDone()
        {
            if (duration <= 0)
                return true;
            else
                return false;
        }
    }
}
