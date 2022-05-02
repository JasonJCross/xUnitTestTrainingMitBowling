using System;
using System.Linq;

namespace BowlingStandard
{
    public class Bowling
    {
        private const int DefaultTotalFrames = 10;
        private int CurrentFrame { get; set; }
        private Frames Frames { get; set; }

        public Bowling() : this(DefaultTotalFrames)
        {
        }

        public Bowling(int totalFrames)
        {
            TotalFrames = totalFrames;
            NewGame();
        }

        public int TotalFrames { get; set; }

        public int Score => Frames.LastOrDefault()?.GetScore() ?? 0;

        /// <summary>
        /// Records the next frame.
        /// Usage: RecordFrame(5,5) for a single spare frame
        /// RecordFrame(10,0,10) for a final frame Strike, Gutter, Strike
        /// </summary>
        /// <param name="scores"></param>
        public Bowling RecordFrame(params int[] scores)
        {
            if (scores == null) { throw new ArgumentNullException(nameof(scores)); }
            var frame = Frames.GetByIndex(CurrentFrame);

            if (frame == null) { throw new ArgumentException($"Invalid Frame. [{CurrentFrame}]"); }

            if (scores.Length > 2 && (frame is FinalFrame) == false) { throw new ArgumentException($"Too many scores. [{scores.Length}]");}

            foreach (var score in scores)
            {
                frame.AddBall(score);
            }

            CurrentFrame++;
            return this;
        }

        public Bowling NewGame()
        {
            Frames?.Clear();
            Frames = null;
            Frames = Frames.NewGame(TotalFrames);
            CurrentFrame = 0;

            return this;
        }
    }
}
