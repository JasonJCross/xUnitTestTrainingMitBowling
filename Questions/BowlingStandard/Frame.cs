namespace BowlingStandard
{
    public class Frame
    {
        internal const int StrikeValue = 10;

        public Frame()
        {
            Balls = new Balls();
        }

        public Frame PreviousFrame { get; set; }
        public Frame NextFrame { get; set; }
        public Balls Balls { get; }

        public Frame AddBall(int score)
        {
            Balls.Add(new Ball(score));

            return this;
        }

        public int GetTwoBalls()
        {
            var returnValue = Balls.GetByNumber(1)?.Score ?? 0 + Balls.GetByNumber(2)?.Score ?? 0;

            if (Balls.Count < 2)
            {
                returnValue += NextFrame?.GetOneBall() ?? 0;
            }

            return returnValue;
        }

        public virtual int GetScore()
        {
            var returnValue = PreviousFrame?.GetScore() ?? 0;

            returnValue += Balls.Total;

            switch (Balls.Count)
            {
                case 1:
                    if (Balls.Total == StrikeValue) { returnValue += NextFrame?.GetTwoBalls() ?? 0; }
                    break;
                case 2:
                    if (Balls.Total == StrikeValue) { returnValue += NextFrame?.GetOneBall() ?? 0; }
                    break;
            }

            return returnValue;
        }

	    private int GetOneBall()
	    {
		    return Balls[1]?.Score ?? 0;
	    }
    }
}
