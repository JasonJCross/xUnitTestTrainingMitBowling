using System.Collections.Generic;

namespace BowlingStandard
{
    public class NonStandardList<T> : List<T>
    {
        public T GetByNumber(int number)
        {
            var nonStandardNumber = number - 1;
            return Count < number ? default(T) : this[nonStandardNumber];
        }

        public T GetByIndex(int index)
        {
            return Count <= index ? default(T) : this[index];
        }
    }
}
