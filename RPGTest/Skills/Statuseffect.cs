using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class Statuseffect : IEffect
    {
        public int duration { get; set; }
        public int damage { get; set; }

        public void Execute(int skill, int strg, ref Result result)
        {
            Random r1 = new Random();
            Random r2 = new Random();

            damage = Convert.ToInt32((r1.Next(skill / 5, (skill / 3) * 1000)) / 1000);

            result.statuseffect.Add(this);
        }
    }
}
