using System.Configuration;
using System.Linq;

namespace RPG
{
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

        [ConfigurationProperty("manaCosts", IsRequired = true, IsKey = false)]
        public string ManaCosts
        {
            get
            {
                return this["manaCosts"] as string;
            }
            set
            {
                this["manaCosts"] = value;
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
