using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace RPG
{
    class Movie
    {
        Video video;
        VideoPlayer videoPlayer;

        Texture2D videoTexture;
        Rectangle screenSize;

        string videoPath;
        
        int state = 0;
        public Movie(string videoPath)
        {
            this.videoPath = videoPath;
        }

        public void Initialize()
        {
            videoPlayer = new VideoPlayer();
        }
        public void LoadContent(ContentManager content)
        {
            video = content.Load<Video>(videoPath);
            screenSize = new Rectangle(0, 0, 720, 576);
            if (state == 0)
            {
                videoPlayer.Play(video);
            }
        }

        public void Update()
        {
            if (videoPlayer.State == MediaState.Stopped && state != 1)
            {
                state = 1;
            }

            // Only call GetTexture if a video is playing or paused
            if (videoPlayer.State != MediaState.Stopped)
            {
                videoTexture = videoPlayer.GetTexture();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case 0:
                    spriteBatch.Draw(videoTexture, screenSize, Color.White);
                    break;
                case 1:
                    break;
            }  
        }
    }
}
