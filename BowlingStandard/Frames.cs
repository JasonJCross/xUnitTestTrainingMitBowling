using System.Linq;

namespace BowlingStandard
{
    public class Frames : NonStandardList<Frame>
    {
        private Frames()
        {
        }

        public static Frames NewGame(int totalFrames)
        {
            var frames = new Frames();

            for (var i = 0; i < totalFrames - 1; i++)
            {
                frames.Add(new Frame());

                if (i == 0) continue;

                frames[i - 1].NextFrame = frames[i];
                frames[i].PreviousFrame = frames[i - 1];
            }

            frames.Add(new FinalFrame { PreviousFrame = frames.LastOrDefault() });

            return frames;
        }
    }
}
