namespace RPG
{
    public class Mindblown : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Character Target { get; set; }

        public Mindblown(Character source, Character target)
        {
            this.Damage = 0;
            this.Target = target;

            int difference = source.Level - target.Level;

            if (target.FightResistance == 20 || difference <= 0)
            {
                this.Duration = 1;
            }
            else
            {
                if (target.FightResistance >= 15 & difference >= 2)
                {
                    this.Duration = 2;
                }
                else
                {
                    if (target.FightResistance >= 10 & difference >= 3)
                    {
                        this.Duration = 3;
                    }
                    else
                    {
                        if (target.Level < source.Level)
                        {
                            this.Duration = difference;
                        }
                    }
                }
            }
        }

        public int ExecuteStatus()
        {
            this.Target.IsMindBlown = false;

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
