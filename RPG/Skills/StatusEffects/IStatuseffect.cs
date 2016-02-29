namespace RPG
{
    public interface IStatuseffect
    {
        int Duration { get; }
        int Damage { get; }

        //Ausführen des Statuseffektes
        int ExecuteStatus();

        //Abfrage ob Statuseffekt beendet ist
        bool IsDone();

        void UpdateDuration(int durationToAdd);
    }
}