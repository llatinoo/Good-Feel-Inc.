using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills.StatusEffects
{
    class Burn : IStatuseffect
    {
        public int duration { get; set; }
        public int damage { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            Random r1 = new Random();
            Random r2 = new Random();

            foreach (Character target in targets)
            {
                this.damage = Convert.ToInt32((r1.Next(source.fMagic / 5, (source.fMagic / 3) * 1000)) / 1000);
                this.duration = Convert.ToInt32(r2.Next(1, 4 * 1000) / 1000);

                target.statuseffects.Add(this);
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
