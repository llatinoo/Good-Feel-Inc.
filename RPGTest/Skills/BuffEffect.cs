using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    public class BuffEffect : IEffect
    {
        public string 
        public BuffEffect(string attribut)
        {

        }
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target
            }
        }
    }
}
