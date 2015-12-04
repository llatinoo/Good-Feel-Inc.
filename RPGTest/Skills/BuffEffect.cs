using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class BuffEffect : IEffect
    {
        public string Attribut { get; set; }

        public BuffEffect(string attributeToBuff)
        {
            Attribut = attributeToBuff;

        }
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                switch (Attribut.ToLower())
                {
                    case "vitality":
                        target.FightVitality += source.FightMagic / 4;
                        break;
                    case "strength":
                        target.FightStrength += source.FightMagic / 4;
                        break;
                    case "magic":
                        target.FightMagic += source.FightMagic / 4;
                        break;
                    case "defense":
                        target.FightDefense += source.FightMagic / 4;
                        break;
                    case "mana":
                        target.FightMana += source.FightMagic / 4;
                        break;
                    case "luck":
                        target.FightLuck += source.FightMagic / 4;
                        break;
                }
           } 
        }
    }
}
