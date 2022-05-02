using BowlingStandard;
using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingStandardTests
{
    public class BowlingTest
    {
        public static IEnumerable<object[]> BowlingData()
        {
            yield return new object[]
            {
                new []{
                    new []{10}, //1
                    new []{10}, //2
                    new []{10}, //3
                    new []{10}, //4
                    new []{10}, //5
                    new []{10}, //6
                    new []{10}, //7
                    new []{10}, //8
                    new []{10}, //9
                    new []{10,10,10}, //10
                },
                10,
                300
            };
            yield return new object[]
            {
                new []{
                    new []{10}, //1
                    new []{10}, //2
                    new []{10}, //3
                    new []{10}, //4
                    new []{10}, //5
                    new []{10}, //6
                    new []{10}, //7
                    new []{10}, //8
                    new []{10}, //9
                    new []{10,10,9}, //10
                },
                10,
                297
            };
            yield return new object[]
            {
                new []{
                    new []{9,1}, //1 - 19
                    new []{9,1}, //2 - 38
                    new []{9,1}, //3 - 57
                    new []{9,1}, //4 - 76
                    new []{9,1}, //5 - 95
                    new []{9,1}, //6 - 114
                    new []{9,1}, //7 - 133
                    new []{9,1}, //8 - 152
                    new []{9,1}, //9 - 171
                    new []{ 9, 1, 9}, //10 - 181
                },
                10,
                190
            };
        }

        [Theory]
        [MemberData(nameof(BowlingData))]
        public void Score_MemberTests(IEnumerable<int[]> frameData, int totalFrames, int expectedScore)
        {
			// Arrange
			var bowling = new Bowling(totalFrames);

			foreach (var throws in frameData)
            {
                bowling.RecordFrame(throws);
            }

			// Act
            var actualScore = bowling.Score;

			// Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void RecordFrame_NullScores_Test()
        {
			// Arrange
            var bowling = new Bowling();

			// Act
            var result = Assert.Throws<ArgumentNullException>(() => bowling.RecordFrame(null));

			// Assert
            Assert.Equal("scores", result.ParamName);
        }

        [Fact]
        public void RecordFrame_TooMany_Test()
        {
			// Arrange
			var bowling = new Bowling();

			// Act
            var result = Assert.Throws<ArgumentException>(() => bowling.RecordFrame(1, 2, 3));

			// Assert
            Assert.Equal("Too many scores. [3]", result.Message);
        }
    }
}
