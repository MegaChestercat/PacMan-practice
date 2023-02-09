
using System.Media;

namespace PacMan
{
    public class Sound
    {
        SoundPlayer sgame = new SoundPlayer(Resource1.startSound);
        SoundPlayer sgame2 = new SoundPlayer(Resource1.deathSound);
        SoundPlayer sgame3 = new SoundPlayer(Resource1.eatingSound);
        SoundPlayer sgame4 = new SoundPlayer(Resource1.win_sound);
        SoundPlayer sgame5 = new SoundPlayer(Resource1.flawless_sound);

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

        public void flawlessVictory()
        {
            sgame5.PlayLooping();
        }

        public void win()
        {
            sgame4.PlayLooping();
        }

        public void stop()
        {
            sgame.Stop();
            sgame2.Stop();
            sgame3.Stop();
            sgame4.Stop();
            sgame5.Stop();
        }

    }
}