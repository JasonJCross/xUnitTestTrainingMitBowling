using BowlingStandard;
using System.Collections.Generic;
using Xunit;

namespace BowlingStandardTests
{
    public class FrameTest
    {
        public static IEnumerable<object[]> GetFrameData()
        {
            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(10),
                    new Frame().AddBall(10),
                    new Frame().AddBall(10),
                },
                new [] {30,50,60}
            };

            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(1).AddBall(1),
                    new Frame().AddBall(2).AddBall(2),
                    new Frame().AddBall(3).AddBall(3),
                },
                new [] {2,6,12}
            };

            yield return new object[]
            {
                new []
                {
                    new Frame().AddBall(1).AddBall(9),
                    new Frame().AddBall(1).AddBall(9),
                    new Frame().AddBall(1).AddBall(9),
                },
                new [] {11,22,32}
            };
        }

        [Fact]
        public void AddBall_Fluent()
        {
            var frame = new Frame();
            frame.AddBall(1).AddBall(2);

            Assert.Equal(2, frame.Balls.Count);
        }

        [Fact]
        public void GetTwoBalls_Test()
        {
            var nextFrame = new Frame().AddBall(7);
            var frame = new Frame().AddBall(10);
            frame.NextFrame = nextFrame;

            var expectedScore = 17;

            var actualScore = frame.GetTwoBalls();

            Assert.Equal(expectedScore, actualScore);
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
