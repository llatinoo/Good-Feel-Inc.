using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RPG
{
    public class SkillCadreDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Skills")]
        public AllSkillsElementCollection Sceneses
        {
            get
            {
                return this["AllSkills"] as AllSkillsElementCollection;
            }
        }
    }


    public class AllSkillsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DefinedSkillElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DefinedSkillElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "DefinedSkill"; }
        }

        public DefinedSkillElement this[int index]
        {
            get { return (DefinedSkillElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public DefinedSkillElement this[string id]
        {
            get { return (DefinedSkillElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }


    public class DefinedSkillElement : ConfigurationElement
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

        [ConfigurationProperty("Effects")]
        public EffectsElementCollection TextBoxes
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
