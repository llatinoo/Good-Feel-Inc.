using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RPG
{
    public class PartySkillCadreDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Chars")]
        public CharsElementCollection Chars
        {
            get { return this["Chars"] as CharsElementCollection; }
        }
    }


    public class CharsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CharElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CharElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "Char"; }
        }

        public CharElement this[int index]
        {
            get { return (CharElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public CharElement this[string id]
        {
            get { return (CharElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }

    public class CharElement : ConfigurationElement
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

        [ConfigurationProperty("CharSkills")]
        public CharSkillsElementCollection CharSkills
        {
            get
            {
                return this["CharSkills"] as CharSkillsElementCollection;
            }
        }
    }


    public class CharSkillsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CharSkillElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CharSkillElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "CharSkill"; }
        }

        public CharSkillElement this[int index]
        {
            get { return (CharSkillElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        new public CharSkillElement this[string id]
        {
            get { return (CharSkillElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }

    public class CharSkillElement : ConfigurationElement
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
    }
}
