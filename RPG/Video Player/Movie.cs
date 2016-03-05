using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace RPG
{
    class Movie
    {
        Controls controls = new Controls();
        Video video;
        VideoPlayer videoPlayer;
        public VideoPlayer Player
        {
            get { return videoPlayer; }
            set { videoPlayer = value; }
        }

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
            this.videoPlayer = new VideoPlayer();
        }
        public void LoadContent(ContentManager content)
        {
            this.video = content.Load<Video>(this.videoPath);
            this.screenSize = new Rectangle(0, 0, 720, 576);
            if (this.state == 0)
            {
                this.videoPlayer.Play(this.video);
            }
        }

        public void Update()
        {
            if (this.videoPlayer.State == MediaState.Stopped && this.state != 1)
            {
                this.state = 1;
            }

            // Nur wenn Video abgespielt wird oder Pausiert ist wird GetTexture aufgerufen
            if (this.videoPlayer.State != MediaState.Stopped)
            {
                this.videoTexture = this.videoPlayer.GetTexture();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.state)
            {
                case 0:
                    spriteBatch.Draw(this.videoTexture, this.screenSize, Color.White);
                    break;
                case 1:
                    break;
            }  
        }
    }
}
