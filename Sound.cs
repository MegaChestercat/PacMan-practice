
using System.Media;

namespace PacMan
{
    public class Sound
    {
        SoundPlayer sgame = new SoundPlayer(Resource1.startSound);
        SoundPlayer sgame2 = new SoundPlayer(Resource1.deathSound);
        SoundPlayer sgame3 = new SoundPlayer(Resource1.eatingSound);

        public void playStartSound()
        {
            sgame.Play();
        }

        public void playDeathSound()
        {
            sgame2.Play();
        }

        public void playEatingSound()
        {
            sgame3.PlayLooping();
        }

    }
}