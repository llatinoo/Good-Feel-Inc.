namespace RPG.Skills.StatusEffects
{
    //Unterteilung der Statuseffekte
    public interface IStatuseffect
    {
        int Duration { get; }
        int Damage { get; }

        //Ausführen des Statuseffektes
        int ExecuteStatus();

        //Abfrage ob Statuseffekt beendet ist
        bool IsDone();
    }
}
