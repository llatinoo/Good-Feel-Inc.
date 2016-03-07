using System.Collections.Generic;

namespace RPG
{
    public class Blessing : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Character Target { get; set; }

        public Blessing(Character target)
        {
            this.Target = target;
            this.Duration = 1;
            this.Damage = 0;
        }

        public int ExecuteStatus()
        {
            Target.IsBlessed = true;
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
        public void UpdateDuration(int durationToAdd)
        {
            this.Duration += durationToAdd;
        }
    }
}
