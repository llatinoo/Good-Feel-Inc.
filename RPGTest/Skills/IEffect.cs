using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    interface IEffect
    {
        void Execute(int skill, int strg, ref Result result);
    }
}
