using System.Linq;

namespace BowlingStandard
{
    public class Balls : NonStandardList<Ball>
    {
        public int Total => this.Sum(b=>b.Score);
    }
}
