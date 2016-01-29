﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Text;

namespace RPG
{
    public class ClassSkillCadreDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Classes")]
        public ClassesElementCollection Classes
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

        [ConfigurationProperty("ClassSkills")]
        public ClassSkillsElementCollection ClassSkills
        {
            get
            {
                return this["ClassSkills"] as ClassSkillsElementCollection;
            }
        }
    }


    public class ClassSkillsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClassSkillElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClassSkillElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "ClassSkill"; }
        }

        public ClassSkillElement this[int index]
        {
            get { return (ClassSkillElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        new public ClassSkillElement this[string id]
        {
            get { return (ClassSkillElement)this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string)keyToCompare == key);
        }
    }


    public class ClassSkillElement : ConfigurationElement
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
