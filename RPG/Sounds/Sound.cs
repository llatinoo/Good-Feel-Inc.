﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    class Sound
    {
        System.Media.SoundPlayer test = new System.Media.SoundPlayer();
        public void LoadContent(ContentManager content)
        {
            test.SoundLocation = "C:\\Users\\dengler\\Documents\\GitHubVisualStudio\\RPG-Game\\RPG\\Content\\Sounds\\Life_converted.wav";
            test.Load();
            test.Play();
        }
    }
}
