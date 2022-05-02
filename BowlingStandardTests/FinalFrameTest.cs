using System.Collections.Generic;
using BowlingStandard;
using Xunit;

namespace BowlingStandardTests
{
    public class FinalFrameTest
    {
        public static IEnumerable<object[]> GetFrameData()
        {
            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(10), 
                    new Frame().AddBall(10),
                    new FinalFrame().AddBall(10).AddBall(10).AddBall(10),
                },
                new [] {30,60,120}
            };

            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(10),
                    new Frame().AddBall(10),
                    new FinalFrame().AddBall(10).AddBall(10).AddBall(9),
                },
                new [] {30,60, (60+(10+10+9)+(10+9)+9)}
            };

            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(1).AddBall(1),
                    new Frame().AddBall(2).AddBall(2),
                    new FinalFrame().AddBall(3).AddBall(3),
                },
                new [] {2,6,12}
            };

            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(1).AddBall(9),
                    new Frame().AddBall(1).AddBall(9),
                    new FinalFrame().AddBall(1).AddBall(9).AddBall(1),
                },
                new [] {11,22,34}
            };
        }

        [Theory]
        [MemberData(nameof(GetFrameData))]
        public void GetScore_Test(Frame[] frames, int[] expectedScores)
        {
            for (var i = 1; i < frames.Length; i++)
            {
                frames[i - 1].NextFrame = frames[i];
                frames[i].PreviousFrame = frames[i - 1];
            }

            for (var i = 0; i < expectedScores.Length; i++)
            {
                var actualScore = frames[i]?.GetScore();

                Assert.Equal(expectedScores[i], actualScore);
            }
        }
    }
}
