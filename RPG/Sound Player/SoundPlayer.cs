using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    class SoundPlayer
    {
        System.Media.SoundPlayer test = new System.Media.SoundPlayer();

        private String soundName;
        public SoundPlayer(string soundName)
        {
            this.soundName = soundName;
        }
        public void LoadContent(ContentManager content)
        {
            test.SoundLocation = soundName;
            test.Load();
            test.Play();
        }
    }
}
