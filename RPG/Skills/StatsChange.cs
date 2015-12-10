using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class StatsChange : IEffect
    {
        public string Attribut { get; set; }
        public string Sign { get; set; }
        public IStatuseffect Statuseffect { get; set; }

        public StatsChange(string sign, string attributeToBuff)
        {
            Sign = sign;
            Attribut = attributeToBuff;
        }

        public void Execute(Character source, List<Character> targets)
        {
            if (Sign == "+")
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

            if(Sign == "-")
            {
                foreach (Character target in targets)
                {
                    switch (Attribut.ToLower())
                    {
                        case "vitality":
                            target.FightVitality -= source.FightMagic / 4;
                            break;
                        case "strength":
                            target.FightStrength -= source.FightMagic / 4;
                            break;
                        case "magic":
                            target.FightMagic -= source.FightMagic / 4;
                            break;
                        case "defense":
                            target.FightDefense -= source.FightMagic / 4;
                            break;
                        case "mana":
                            target.FightMana -= source.FightMagic / 4;
                            break;
                        case "luck":
                            target.FightLuck -= source.FightMagic / 4;
                            break;
                    }
                }
            }
        }
    }
}
