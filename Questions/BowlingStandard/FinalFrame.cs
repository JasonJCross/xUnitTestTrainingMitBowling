namespace BowlingStandard
{
    public class FinalFrame : Frame
    {
        public override int GetScore()
        {
            var returnValue = PreviousFrame?.GetScore() ?? 0;

            returnValue += Balls.Total;

            if (Balls.Count == 3) return returnValue;

            if (Balls.GetByNumber(1).Score == StrikeValue)
            {
                returnValue += (Balls.GetByNumber(2)?.Score ?? 0) + (Balls.GetByNumber(3)?.Score ?? 0);

                if (Balls.GetByNumber(2).Score == StrikeValue)
                {
                    returnValue += Balls.GetByNumber(3)?.Score ?? 0;
                }
            }
            else
            {
                returnValue += Balls.GetByNumber(3)?.Score ?? 0;
            }

            return returnValue;
        }
    }
}
