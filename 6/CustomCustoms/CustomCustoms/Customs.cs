using System.Collections.Generic;
using System.Linq;

namespace CustomCustoms
{
    public static class Customs
    {
        public static int SumAll(IEnumerable<string> customs)
        {
            return customs.Sum(cu => CountAllAnswers(cu));
        }

        public static int SumAny(IEnumerable<string> customs)
        {
            return customs.Sum(cu => CountAnyAnswers(cu));
        }


        public static int CountAnyAnswers(string custom)
        {
            return custom.Where(c => c >= 'a' && c <= 'z').Distinct().Count();
        }

        public static int CountAllAnswers(string custom)
        {
            return custom.Split('\n')
                .Aggregate("abcdefghijklmnopqrstuvwxyz",
                    (x, y) => new string(x.Intersect(y).ToArray()))
                .Count();
        }
    }
}
