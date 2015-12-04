using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Bleed : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            Random r1 = new Random();

            foreach (Character target in targets)
            {
                bool exists = false;

                foreach (IStatuseffect existingStatus in target.statuseffects)
                {
                    var status = existingStatus as Bleed;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    Duration = Convert.ToInt32(r1.Next(3, 6 * 1000) / 1000);
                    Damage = Convert.ToInt32((r1.Next(source.FightMagic / 7, (source.FightMagic / 5) * 1000)) / 1000);
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
