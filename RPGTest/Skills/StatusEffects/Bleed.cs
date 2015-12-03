using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    public class Bleed : IStatuseffect
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
                    var status = existingStatus as Bleed;
                    if (status != null)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    duration = Convert.ToInt32(r1.Next(3, 6 * 1000) / 1000);
                    damage = Convert.ToInt32((r1.Next(source.fMagic / 7, (source.fMagic / 5) * 1000)) / 1000);
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
