namespace RPG.Skills.StatusEffects
{
    public class Blessing : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Blessing()
        {
            this.Duration = 1;
            this.Damage = 0;
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
