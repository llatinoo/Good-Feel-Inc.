using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Halo : IStatuseffect
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
                    var status = existingStatus as Halo;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    this.Damage -= Convert.ToInt32(target.FightVitality * 0.1);
                    this.Duration = Convert.ToInt32(r1.Next(1, 3 * 1000) / 1000);
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
