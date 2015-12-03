using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    interface IStatuseffect : IEffect
    {
        int duration { get; set; }
        int damage { get; set; }

        bool IsDone();
    }
}
