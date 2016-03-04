using System.Configuration;
using System.Linq;

namespace RPG
{
    //Section für alle Skills
    public class SkillCadreDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Skills")]
        public SkillsElementCollection Skills
        {
            get
            {
                return this["Skills"] as SkillsElementCollection;
            }
        }
    }

    //Struktur der Section

    //Ansammlung von Skill-Elementen
    public class SkillsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SkillElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SkillElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "Skill"; }
        }

        public SkillElement this[int index]
        {
            get { return (SkillElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public SkillElement this[string id]
        {
            get { return (SkillElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }


    //Konkretes Skill Element
    public class SkillElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("level", IsRequired = true, IsKey = false)]
        public string Level
        {
            get
            {
                return this["level"] as string;
            }
            set
            {
                this["level"] = value;
            }
        }

        [ConfigurationProperty("target", IsRequired = true, IsKey = false)]
        public string Target
        {
            get
            {
                return this["target"] as string;
            }
            set
            {
                this["target"] = value;
            }
        }

        [ConfigurationProperty("areaOfEffect", IsRequired = true, IsKey = false)]
        public string AreaOfEffect
        {
            get
            {
                return this["areaOfEffect"] as string;
            }
            set
            {
                this["areaOfEffect"] = value;
            }
        }

        [ConfigurationProperty("Effects")]
        public EffectsElementCollection Effects
        {
            get
            {
                return this["Effects"] as EffectsElementCollection;
            }
        }
    }


    //Ansammlung von Effekt-Elementen
    public class EffectsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EffectElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EffectElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "Effect"; }
        }

        public EffectElement this[int index]
        {
            get { return (EffectElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        new public EffectElement this[string id]
        {
            get { return (EffectElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }


    //Konkretes Effekt-Element
    public class EffectElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
