using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    public interface IEffect
    {
        void Execute(Character source, List<Character> targets);
    }
}
