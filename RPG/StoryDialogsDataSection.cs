using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RPG
{
    public class StoryDialogsDataSection : ConfigurationSection
    {
        [ConfigurationProperty("Scenes")]
        public ScenesElementCollection Sceneses
        {
            get
            {
                return this["Scenes"] as ScenesElementCollection;
            }
        }
    }

    public class ScenesElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SceneElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SceneElement)element).Id;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "Scene"; }
        }

        public SceneElement this[int index]
        {
            get { return (SceneElement) this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public SceneElement this[string id]
        {
            get { return (SceneElement) this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string) keyToCompare == key);
        }
    }

    public class SceneElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public string Id
        {
            get
            {
                return this["id"] as string;
            }
            set
            {
                this["id"] = value;
            }
        }

        [ConfigurationProperty("TextBoxes")]
        public TextBoxesElementCollection TextBoxes
        {
            get
            {
                return this["TextBoxes"] as TextBoxesElementCollection;
            }
        }
    }

    public class TextBoxesElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TextBoxElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TextBoxElement)element).Id;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "TextBox"; }
        }

        public TextBoxElement this[int index]
        {
            get { return (TextBoxElement) this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        new public TextBoxElement this[string id]
        {
            get { return (TextBoxElement) this.BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            var keys = this.BaseGetAllKeys();

            return keys.Any(keyToCompare => (string) keyToCompare == key);
        }
    }

    public class TextBoxElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public string Id
        {
            get
            {
                return this["id"] as string;
            }
            set
            {
                this["id"] = value;
            }
        }

        [ConfigurationProperty("speaker", IsRequired = true)]
        public string Speaker
        {
            get { return (string)this["speaker"]; }
            set { this["speaker"] = value; }
        }

        [ConfigurationProperty("speakerPicture", IsRequired = true)]
        public string SpeakerPicture
        {
            get { return (string)this["speakerPicture"]; }
            set { this["speakerPicture"] = value; }
        }


        [ConfigurationProperty("listener", IsRequired = true)]
        public string Listener
        {
            get { return (string)this["listener"]; }
            set { this["listener"] = value; }
        }


        [ConfigurationProperty("listenerPicture", IsRequired = true)]
        public string ListenerPicture
        {
            get { return (string)this["listenerPicture"]; }
            set { this["listenerPicture"] = value; }
        }


        [ConfigurationProperty("row1", IsRequired = true)]
        public string Row1
        {
            get { return (string)this["row1"]; }
            set { this["row1"] = value; }
        }


        [ConfigurationProperty("row2", IsRequired = true)]
        public string Row2
        {
            get { return (string)this["row2"]; }
            set { this["row2"] = value; }
        }


        [ConfigurationProperty("row3", IsRequired = true)]
        public string Row3
        {
            get { return (string)this["row3"]; }
            set { this["row3"] = value; }
        }


        [ConfigurationProperty("row4", IsRequired = true)]
        public string Row4
        {
            get { return (string)this["row4"]; }
            set { this["row4"] = value; }
        }
    }
}

//Auslesen der app.config
//var dialogsDataSection =
//    ConfigurationManager.GetSection("Story") as StoryDialogsDataSection;

//var dialogWithIdOne =
//    dialogsDataSection.Sceneses.Cast<SceneElement>()
//        .SingleOrDefault(dialogElement => dialogElement.Id == "0");
            
//foreach (TextBoxElement dialogElementsElement in dialogWithIdOne.TextBoxes)
//{
//      Debug.WriteLine(dialogElementsElement.Id + ": " + dialogElementsElement.Speaker);
//}