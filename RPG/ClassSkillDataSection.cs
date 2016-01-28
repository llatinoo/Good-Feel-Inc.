using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Text;

namespace RPG
{
    public class ClassSkillDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Classes")]
        public ClassesElementCollection Sceneses
        {
            get
            {
                return this["Classes"] as ClassesElementCollection;
            }
        }
    }


    public class ClassesElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClassElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClassElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "Class"; }
        }

        public ClassElement this[int index]
        {
            get { return (ClassElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public ClassElement this[string id]
        {
            get { return (ClassElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }


    public class ClassElement : ConfigurationElement
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

        [ConfigurationProperty("Skills")]
        public SkillsElementCollection TextBoxes
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
    }
}
