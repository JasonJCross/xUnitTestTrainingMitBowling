using System.Collections.Generic;
using BowlingStandard;
using Xunit;

namespace BowlingStandardTests
{
    public class BallsTest
    {
        public static IEnumerable<object[]> GetCleanData()
        {
            yield return new object[] { new []{ new Ball(10), new Ball(7) }, 17 };
            yield return new object[] { new[] { new Ball(7) }, 7 };
            yield return new object[] { new[] { new Ball(1), new Ball(7) }, 8 };
            yield return new object[] { new[] { new Ball(1), new Ball(1), new Ball(1), new Ball(1), new Ball(1), new Ball(1) }, 6 };
            yield return new object[] { new[] { new Ball(10), new Ball(7) }, 17 };
            yield return new object[] { new Ball[] {}, 0 };
        }

        [Theory]
        [MemberData(nameof(GetCleanData))]
        public void MemberDataTotal_HappyPath(Ball[] ballArray, int expectedTotal)
        {
			// Arrange
            var balls = new Balls();
            foreach (var ball in ballArray)
            {
                balls.Add(ball);
            }

			// Act
            var actualTotal = balls.Total;

			// Assert
            Assert.Equal(expectedTotal, actualTotal);
        }

		[Theory]
		[InlineData(10, 9, 1)]
		[InlineData(9, 8, 1)]
		[InlineData(8, 7, 1)]
		[InlineData(7, 6, 1)]
		[InlineData(6, 5, 1)]
		[InlineData(5, 4, 1)]
		[InlineData(-9, 1, -10)]
		[InlineData(0, int.MaxValue, -int.MaxValue)]
		[InlineData(300, 200, 100)]
		public void InlineDataTotal_Tests(int expectedTotal, int ball1, int ball2)
		{
			// Arrange
			var balls = new Balls
			{
				new Ball(ball1),
				new Ball(ball2)
			};

			// Act
			var actualTotal = balls.Total;

			// Assert
			Assert.Equal(expectedTotal, actualTotal);
		}




	}
}
