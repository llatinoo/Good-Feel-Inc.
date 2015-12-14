using RPG.Characters;

namespace RPG.Skills.StatusEffects
{
    public class Mindblown : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Mindblown(Character source, Character target)
        {
            this.Damage = 0;
          
            if (target.Level > source.Level)
                this.Duration = 1;
            else
                this.Duration = source.Level - target.Level;
        }

        public int ExecuteStatus()
        {
            this.Duration--;
            return this.Damage;
        }

        public bool IsDone()
        {
            if (this.Duration <= 0)
                return true;
            else
                return false;
        }
    }
}
