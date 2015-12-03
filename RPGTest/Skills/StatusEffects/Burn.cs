using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills.StatusEffects
{
    public class Burn : IStatuseffect
    {
        public int duration { get; set; }
        public int damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            Random r1 = new Random();

            foreach (Character target in targets)
            {
                bool exists = false;

                foreach (IStatuseffect existingStatus in target.statuseffects)
                {
                    var status = existingStatus as Burn;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    this.damage = Convert.ToInt32((r1.Next(source.fMagic / 5, (source.fMagic / 3) * 1000)) / 1000);
                    this.duration = Convert.ToInt32(r1.Next(1, 4 * 1000) / 1000);
                    target.statuseffects.Add(this);
                }
            }
        }

        public bool IsDone ()
        {
            if (duration <= 0)
                return true;
            else
                return false;
        }
    }
}
