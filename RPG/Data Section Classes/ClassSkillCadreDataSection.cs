using System.Configuration;
using System.Linq;

namespace RPG.Data_Section_Classes
{
    //Section für Klassen-Skill zuordnung
    public class ClassSkillCadreDataSection : ConfigurationSection
    {
        //Benennung der Section
        [ConfigurationProperty("Classes")]
        public ClassesElementCollection Classes
        {
            get
            {
                return this["Classes"] as ClassesElementCollection;
            }
        }
    }

    //Struktur der Section

    //Ansammlung von Klassen-Elementen
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


    //Konkretes Klassen-Element
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


    //Ansammlung von Skill-Element-Referenzen
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


    //Konkrete von Skill-Element-Referenz
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
