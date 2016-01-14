using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;

namespace RPG.Skills
{
    public enum Attributes
    {
        FightVitality,
        FightMana,
        FightStrength,
        FightMagic,
        FightDefense,
        FightResistance,
        FightLuck
    }

    public enum Actions
    {
        Add,
        Substract
    }

    //Klasse zur Unterscheidung der Buffs und Debuffs
    public class StatActions
    {
        //Je nach Aufruf Subtraktion oder Addition, erzeugt intern ein neues Objekt
        public static StatActions Add = new StatActions((value, delta) => value + delta);
        public static StatActions Substract = new StatActions((value, delta) => value - delta);

        public int GetActionResult(int value, int delta)
        {            
            return this.actionFunc(value, delta);
        }

        private readonly Func<int, int, int> actionFunc;

        //Es können keine Instanzen von außen erzeugt werden
        private StatActions(Func<int, int, int> actionFunc)
        {
            this.actionFunc = actionFunc;
        }
    }

    public class StatsChange : IEffect
    {
        public Attributes Attribute { get; private set; }
        public StatActions StatAction { get; private set; }

        public StatsChange(StatActions statAction, Attributes attributeToBuff)
        {
            this.StatAction = statAction;
            this.Attribute = attributeToBuff;
        }

        public void Execute(Character source, List<Character> targets)
        {
            var propertyInfo = typeof(Character).GetProperty(this.Attribute.ToString());

            if (propertyInfo == null)
            {
                throw new ArgumentException("Property does not exist!");
            }

            var valueDelta = source.FightMagic / 4;

            foreach (Character target in targets)
            {
                var oldValue = (int)propertyInfo.GetValue(target, null);

                var newValue = this.StatAction.GetActionResult(oldValue, valueDelta);

                propertyInfo.SetValue(target, newValue, null);
            }
        }
    }
}
