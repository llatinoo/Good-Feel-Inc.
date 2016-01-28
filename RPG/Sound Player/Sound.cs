using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    class Sound
    {
        System.Media.SoundPlayer test = new System.Media.SoundPlayer();

        private String soundName;
        public Sound(string soundName)
        {
            this.soundName = soundName;
        }
        public void LoadContent()
        {
            test.SoundLocation = soundName;
            test.Load();
            test.Play();
        }
    }
}
