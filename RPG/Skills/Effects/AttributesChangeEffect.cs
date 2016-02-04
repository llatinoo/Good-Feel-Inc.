using System;
using System.Collections.Generic;

namespace RPG
{
    public enum Attributes
    {
        FightVitality,
        FightManaPool,
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
    public class AttributeActions
    {
        //Je nach Aufruf Subtraktion oder Addition, erzeugt intern ein neues Objekt
        public static AttributeActions Add = new AttributeActions((value, delta) => value + delta);
        public static AttributeActions Substract = new AttributeActions((value, delta) => value - delta);

        public int GetActionResult(int value, int delta)
        {            
            return this.actionFunc(value, delta);
        }

        private readonly Func<int, int, int> actionFunc;

        //Es können keine Instanzen von außen erzeugt werden
        private AttributeActions(Func<int, int, int> actionFunc)
        {
            this.actionFunc = actionFunc;
        }
    }

    public class AttributesChangeEffect : IEffect
    {
        public Attributes Attribute { get; private set; }
        public AttributeActions AttributeAction { get; private set; }

        public AttributesChangeEffect(AttributeActions attributeAction, Attributes attributeToBuff)
        {
            this.AttributeAction = attributeAction;
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

                var newValue = this.AttributeAction.GetActionResult(oldValue, valueDelta);

                propertyInfo.SetValue(target, newValue, null);
            }
        }
    }
}
