using Microsoft.Xna.Framework.Content;

namespace RPG.Sounds
{
    class Sound
    {
        System.Media.SoundPlayer test = new System.Media.SoundPlayer();
        public void LoadContent(ContentManager content)
        {
            this.test.SoundLocation = "Content\\Sounds\\Life_converted.wav";
            this.test.Load();
            this.test.Play();
        }
    }
}
