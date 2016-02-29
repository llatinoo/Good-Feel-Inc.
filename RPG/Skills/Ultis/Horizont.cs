using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
{
    public class Horizont : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            List<Character> enemies = new List<Character>();
            List<Character> party = new List<Character>();
            foreach (var target in targets)
            {
                if (target.GetType() == typeof (Enemy))
                {
                    enemies.Add(target);
                }
                if (target.GetType() == typeof (PartyMember))
                {
                    party.Add(target);
                }
            }

            new Damage().Execute(source, enemies);
            new Damage().Execute(source, enemies);
            new Damage().Execute(source, enemies);
            new Mindblow().Execute(source, enemies);

            new Damage().Execute(source, party);
            new Mindblow().Execute(source, new List<Character>() {source});
        }
    }
}
